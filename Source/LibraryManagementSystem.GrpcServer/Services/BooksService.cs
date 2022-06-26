using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using LibraryManagementSystem.Core.Interfaces;
using log4net;

namespace LibraryManagementSystem.GrpcServer.Services
{
    public class BooksService : Books.BooksBase
    {
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
        private readonly IBookBl _bookBl;

        public BooksService(IBookBl bookBl)
        {
            _bookBl = bookBl;
        }

        public override async Task GetTopBorrowedBooks(GetTopBorrowedBooksRequest request, IServerStreamWriter<GetTopBorrowedBooksResponse> responseStream, ServerCallContext context)
        {
            var getTopBorrowedBooksResponse = new GetTopBorrowedBooksResponse();

            try
            {
                var topBookDetails = await _bookBl.GetTopBorrowedBooks(request.NumberOfBooks);

                if (topBookDetails.Count == 0)
                {
                    await responseStream.WriteAsync(getTopBorrowedBooksResponse);
                }
                else
                {
                    foreach (var topBookDetail in topBookDetails)
                    {
                        var bookResponse = new TopBookDetailResponse
                        {
                            Book = new BookResponse
                            {
                                Id = topBookDetail.Id,
                                Isbn = topBookDetail.ISBN,
                                Title = topBookDetail.Title,
                                Description = topBookDetail.Description,
                                TotalPages = topBookDetail.TotalPages,
                                PublishedDate = Timestamp.FromDateTime(DateTime.SpecifyKind(topBookDetail.PublishedDate, DateTimeKind.Utc)),
                                PublisherId = topBookDetail.PublisherId
                            },
                            CopiesLoaned = topBookDetail.CopiesLoaned
                        };

                        getTopBorrowedBooksResponse.Result = bookResponse;

                        await responseStream.WriteAsync(getTopBorrowedBooksResponse);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error($"{exception.Message} - {exception.StackTrace}");

                getTopBorrowedBooksResponse.Errors.Add(new RepeatedField<ErrorsResponse>
                {
                    new ErrorsResponse
                    {
                        Message = exception.Message,
                        StackTrace = exception.StackTrace
                    }
                });

                await responseStream.WriteAsync(getTopBorrowedBooksResponse);
            }
        }

        public override async Task<GetBookStatusResponse> GetBookStatus(GetBookStatusRequest request, ServerCallContext context)
        {
            var getBookStatusResponse = new GetBookStatusResponse();
            try
            {
                var bookStatus = await _bookBl.GetBookStatus(request.BookId);

                if (bookStatus == null)
                {
                    return getBookStatusResponse;
                }

                var bookStatusResponse = new BookStatusResponse
                {
                    Available = bookStatus.Available,
                    Borrowed = bookStatus.Borrowed,
                    Lost = bookStatus.Lost
                };

                getBookStatusResponse.Result = bookStatusResponse;
            }
            catch (Exception exception)
            {
                _logger.Error($"{exception.Message} - {exception.StackTrace}");

                getBookStatusResponse.Errors.Add(new RepeatedField<ErrorsResponse>
                {
                    new ErrorsResponse
                    {
                        Message = exception.Message,
                        StackTrace = exception.StackTrace
                    }
                });
            }

            return getBookStatusResponse;
        }

        public override async Task GetTopBorrowers(GetTopBorrowersRequest request, IServerStreamWriter<GetTopBorrowersResponse> responseStream, ServerCallContext context)
        {
            var getTopBorrowersResponse = new GetTopBorrowersResponse();

            try
            {
                var topBorrowerDetails = await _bookBl.GetTopBorrowers(request.NumberOfBorrowers, request.FromDate.ToDateTime(), request.ToDate.ToDateTime());
                
                if (topBorrowerDetails.Count == 0)
                {
                    await responseStream.WriteAsync(getTopBorrowersResponse);
                }
                else
                {
                    foreach (var topBorrowerDetail in topBorrowerDetails)
                    {
                        var topBorrowerDetailResponse = new TopBorrowerDetailResponse
                        {
                            Borrower = new Borrower
                            {
                                Id = topBorrowerDetail.Id,
                                FirstName = topBorrowerDetail.FirstName,
                                LastName = topBorrowerDetail.LastName,
                                ContactNumber = topBorrowerDetail.ContactNumber,
                                Address = topBorrowerDetail.Address
                            },
                            BooksLoaned = topBorrowerDetail.BooksLoaned
                        };

                        getTopBorrowersResponse.Result = topBorrowerDetailResponse;

                        await responseStream.WriteAsync(getTopBorrowersResponse);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error($"{exception.Message} - {exception.StackTrace}");

                getTopBorrowersResponse.Errors.Add(new RepeatedField<ErrorsResponse>
                {
                    new ErrorsResponse
                    {
                        Message = exception.Message,
                        StackTrace = exception.StackTrace
                    }
                });

                await responseStream.WriteAsync(getTopBorrowersResponse);
            }
        }

        public override async Task GetBorrowersBorrowedBookCountForEachTimeFrame(GetBorrowersBorrowedBookCountForEachTimeFrameRequest request, IServerStreamWriter<GetBorrowersBorrowedBookCountForEachTimeFrameResponse> responseStream, ServerCallContext context)
        {
            var getBorrowersBorrowedBookCountForEachTimeFrameResponse = new GetBorrowersBorrowedBookCountForEachTimeFrameResponse();

            try
            {
                var borrowerBorrowedTimeFrameCounts = await _bookBl.GetBorrowersBorrowedBookCountForEachTimeFrame(request.BorrowId);

                if (borrowerBorrowedTimeFrameCounts.Count == 0)
                {
                    await responseStream.WriteAsync(getBorrowersBorrowedBookCountForEachTimeFrameResponse);
                }
                else
                {
                    foreach (var borrowerBorrowedTimeFrameCount in borrowerBorrowedTimeFrameCounts)
                    {
                        var borrowerBorrowedTimeFrameCountResponse = new BorrowerBorrowedTimeFrameCountResponse
                        {
                            FromDate = Timestamp.FromDateTime(
                                DateTime.SpecifyKind(borrowerBorrowedTimeFrameCount.FromDate, DateTimeKind.Utc)),
                            ToDate = Timestamp.FromDateTime(DateTime.SpecifyKind(borrowerBorrowedTimeFrameCount.ToDate,
                                DateTimeKind.Utc)),
                            BooksLoaned = borrowerBorrowedTimeFrameCount.BooksLoaned
                        };

                        getBorrowersBorrowedBookCountForEachTimeFrameResponse.Result =
                            borrowerBorrowedTimeFrameCountResponse;

                        await responseStream.WriteAsync(getBorrowersBorrowedBookCountForEachTimeFrameResponse);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error($"{exception.Message} - {exception.StackTrace}");

                getBorrowersBorrowedBookCountForEachTimeFrameResponse.Errors.Add(new RepeatedField<ErrorsResponse>
                {
                    new ErrorsResponse
                    {
                        Message = exception.Message,
                        StackTrace = exception.StackTrace
                    }
                });

                await responseStream.WriteAsync(getBorrowersBorrowedBookCountForEachTimeFrameResponse);
            }
        }

        public override async Task GetOtherBooksLoanedByBorrowersOfASpecificBook(GetOtherBooksLoanedByBorrowersOfASpecificBookRequest request, IServerStreamWriter<GetOtherBooksLoanedByBorrowersOfASpecificBookResponse> responseStream, ServerCallContext context)
        {
            var getOtherBooksLoanedByBorrowersOfASpecificBookResponse = new GetOtherBooksLoanedByBorrowersOfASpecificBookResponse();

            try
            {
                var books = await _bookBl.GetOtherBooksLoanedByBorrowersOfASpecificBook(request.BookId);

                if (books.Count == 0)
                {
                    await responseStream.WriteAsync(getOtherBooksLoanedByBorrowersOfASpecificBookResponse);
                }
                else
                {
                    foreach (var book in books)
                    {
                        var bookResponse = new BookResponse
                        {
                            Id = book.Id,
                            Isbn = book.ISBN,
                            Title = book.Title,
                            Description = book.Description,
                            TotalPages = book.TotalPages,
                            PublishedDate = Timestamp.FromDateTime(DateTime.SpecifyKind(book.PublishedDate, DateTimeKind.Utc)),
                            PublisherId = book.PublisherId
                        };

                        getOtherBooksLoanedByBorrowersOfASpecificBookResponse.Result = bookResponse;

                        await responseStream.WriteAsync(getOtherBooksLoanedByBorrowersOfASpecificBookResponse);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error($"{exception.Message} - {exception.StackTrace}");

                getOtherBooksLoanedByBorrowersOfASpecificBookResponse.Errors.Add(new RepeatedField<ErrorsResponse>
                {
                    new ErrorsResponse
                    {
                        Message = exception.Message,
                        StackTrace = exception.StackTrace
                    }
                });

                await responseStream.WriteAsync(getOtherBooksLoanedByBorrowersOfASpecificBookResponse);
            }
        }

        public override async Task GetAllBooks(Empty request, IServerStreamWriter<GetAllBooksResponse> responseStream, ServerCallContext context)
        {
            var getAllBooksResponse = new GetAllBooksResponse();

            try
            {
                var books = await _bookBl.GetAllBooks();

                if (books.Count == 0)
                {
                    await responseStream.WriteAsync(getAllBooksResponse);
                }
                else
                {
                    foreach (var book in books)
                    {
                        var bookResponse = new BookResponse
                        {
                            Id = book.Id,
                            Isbn = book.ISBN,
                            Title = book.Title,
                            Description = book.Description,
                            TotalPages = book.TotalPages,
                            PublishedDate =
                                Timestamp.FromDateTime(DateTime.SpecifyKind(book.PublishedDate, DateTimeKind.Utc)),
                            PublisherId = book.PublisherId
                        };

                        getAllBooksResponse.Result = bookResponse;

                        await responseStream.WriteAsync(getAllBooksResponse);
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error($"{exception.Message} - {exception.StackTrace}");

                getAllBooksResponse.Errors.Add(new RepeatedField<ErrorsResponse>
                {
                    new ErrorsResponse
                    {
                        Message = exception.Message,
                        StackTrace = exception.StackTrace
                    }
                });

                await responseStream.WriteAsync(getAllBooksResponse);
            }
        }

        public override async Task<GetBookByIdResponse> GetBookById(GetBookByIdRequest request, ServerCallContext context)
        {
            var getBookByIdResponse = new GetBookByIdResponse();

            try
            {
                var book = await _bookBl.GetBookById(request.BookId);

                if (book == null)
                {
                    return getBookByIdResponse;
                }

                var bookResponse = new BookResponse
                {
                    Id = book.Id,
                    Isbn = book.ISBN,
                    Title = book.Title,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    PublishedDate = Timestamp.FromDateTime(DateTime.SpecifyKind(book.PublishedDate, DateTimeKind.Utc)),
                    PublisherId = book.PublisherId
                };

                getBookByIdResponse.Result = bookResponse;
            }
            catch (Exception exception)
            {
                _logger.Error($"{exception.Message} - {exception.StackTrace}");

                getBookByIdResponse.Errors.Add(new RepeatedField<ErrorsResponse>
                {
                    new ErrorsResponse
                    {
                        Message = exception.Message,
                        StackTrace = exception.StackTrace
                    }
                });
            }

            return getBookByIdResponse;
        }

        public override async Task<GetBookHistoryResponse> GetBookHistory(GetBookHistoryRequest request, ServerCallContext context)
        {
            var getBookHistoryResponse = new GetBookHistoryResponse();

            try
            {
                var bookHistory = await _bookBl.GetBookHistory(request.BookId);

                if (bookHistory == null)
                {
                    return getBookHistoryResponse;
                }

                var bookHistoryResponse = new BookHistoryResponse
                {
                    Book = new BookResponse
                    {
                        Id = bookHistory.Id,
                        Isbn = bookHistory.ISBN,
                        Title = bookHistory.Title,
                        Description = bookHistory.Description,
                        TotalPages = bookHistory.TotalPages,
                        PublishedDate = Timestamp.FromDateTime(DateTime.SpecifyKind(bookHistory.PublishedDate, DateTimeKind.Utc)),
                        PublisherId = bookHistory.PublisherId
                    }
                };

                if (bookHistory.BookHistoryDetails != null && bookHistory.BookHistoryDetails.Count > 0)
                {
                    bookHistoryResponse.BookHistoryDetails.AddRange(bookHistory.BookHistoryDetails.Select(x => new BookHistoryDetail
                    {
                        FromDate = Timestamp.FromDateTime(DateTime.SpecifyKind(x.FromDate, DateTimeKind.Utc)),
                        ToDate = Timestamp.FromDateTime(DateTime.SpecifyKind(x.ToDate, DateTimeKind.Utc)),
                        ReturnDate = Timestamp.FromDateTime(DateTime.SpecifyKind(x.ReturnDate, DateTimeKind.Utc)),
                        DaysLoaned = x.DaysLoaned
                    }));
                }

                getBookHistoryResponse.Result = bookHistoryResponse;
            }
            catch (Exception exception)
            {
                _logger.Error($"{exception.Message} - {exception.StackTrace}");

                getBookHistoryResponse.Errors.Add(new RepeatedField<ErrorsResponse>
                {
                    new ErrorsResponse
                    {
                        Message = exception.Message,
                        StackTrace = exception.StackTrace
                    }
                });
            }

            return getBookHistoryResponse;
        }

        public override async Task<GetBookAverageReadRateResponse> GetBookAverageReadRate(GetBookAverageReadRateRequest request, ServerCallContext context)
        {
            var getBookAverageReadRateResponse = new GetBookAverageReadRateResponse();

            try
            {
                var bookAverageReadRate = await _bookBl.GetBookAverageReadRate(request.BookId);

                var bookAverageReadRateResponse = new BookAverageReadRateResponse
                {
                    BookAverageReadRate = bookAverageReadRate
                };

                getBookAverageReadRateResponse.Result = bookAverageReadRateResponse;
            }
            catch (Exception exception)
            {
                _logger.Error($"{exception.Message} - {exception.StackTrace}");

                getBookAverageReadRateResponse.Errors.Add(new RepeatedField<ErrorsResponse>
                {
                    new ErrorsResponse
                    {
                        Message = exception.Message,
                        StackTrace = exception.StackTrace
                    }
                });
            }

            return getBookAverageReadRateResponse;
        }
    }
}
