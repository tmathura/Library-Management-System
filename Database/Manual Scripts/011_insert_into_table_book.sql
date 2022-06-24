SET IDENTITY_INSERT [dbo].[book] ON;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 1)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (1, 9780553564945, N'Magician: Apprentice',
     N'An alternate cover edition of this ISBN can be found here.

To the forest on the shore of the Kingdom of the Isles, the orphan Pug came to study with the master magician Kulgan. His courage won him a place at court and the heart of a lovely Princess, but he was ill at ease with normal wizardry. Yet his strange magic may save two worlds from dark beings who opened spacetime to renew the age-old battle between Order and Chaos.',
     485, N'1994-01-01T00:00:00', 1);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 2)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (2, 9780553564938, N'Magician: Master',
     N'He held the fate of two worlds in his hands...

Once he was an orphan called Pug, apprenticed to a sorcerer of the enchanted land of Midkemia.. Then he was captured and enslaved by the Tsurani, a strange, warlike race of invaders from another world.

There, in the exotic Empire of Kelewan, he earned a new name--Milamber. He learned to tame the unnimagined powers that lay withing him. And he took his place in an ancient struggle against an evil Enemy older than time itself',
     499, N'1993-01-01T00:00:00', 1);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 3)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (3, 9780586064177, N'Silverthorn',
     N'A poisoned bolt has struck down the Princess Anita on the day of her wedding to Prince Arutha of Krondor.

To save his beloved, Arutha sets out in search of the mystic herb called Silverthorn that only grows in the dark and forbidding land of the Spellweavers.

Accompanied by a mercenary, a minstrel, and a clever young thief, he will confront an ancient evil and do battle with the dark powers that threaten the enchanted realm of Midkemia.',
     432, N'1986-01-01T00:00:00', 2);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 4)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (4, 9780586066881, N'A Darkness At Sethanon',
     N'A Darkness at Sethanon is the stunning climax to Raymond E. Feist''s brilliant epic fantasy trilogy, the Riftwar Saga.

Here be dragons and sorcery, swordplay, quests, pursuits, intrigues, stratagems, journeys to the darkest realms of the dead and titanic battles between the forces of good and darkest evil.

Here is the final dramatic confrontation between Arutha and Murmandamus - and the perilous quest of Pug the magician and Tomas the warrior for Macros the Black. A Darkness at Sethanon is heroic fantasy of the highest excitement and on the grandest scale, a magnificent conclusion to one of the great fantasy sagas of our time.',
     527, N'1987-01-01T00:00:00', 2);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 5)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (5, 9780345503800, N'The Warded Man',
     N'As darkness falls after sunset, the corelings rise�demons who possess supernatural powers and burn with a consuming hatred of humanity. For hundreds of years the demons have terrorized the night, slowly culling the human herd that shelters behind magical wards�symbols of power whose origins are lost in myth and whose protection is terrifyingly fragile. It was not always this way. Once, men and women battled the corelings on equal terms, but those days are gone. Night by night the demons grow stronger, while human numbers dwindle under their relentless assault. Now, with hope for the future fading, three young survivors of vicious demon attacks will dare the impossible, stepping beyond the crumbling safety of the wards to risk everything in a desperate quest to regain the secrets of the past. Together, they will stand against the night.',
     416, N'2009-03-10T00:00:00', 3);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 6)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (6, 9780345503817, N'The Desert Spear',
     N'The sun is setting on humanity. The night now belongs to voracious demons that prey upon a dwindling population forced to cower behind half-forgotten symbols of power.

Legends tell of a Deliverer: a general who once bound all mankind into a single force that defeated the demons. But is the return of the Deliverer just another myth? Perhaps not.

Out of the desert rides Ahmann Jardir, who has forged the desert tribes into a demon-killing army. He has proclaimed himself Shar''Dama Ka, the Deliverer, and he carries ancient weapons--a spear and a crown--that give credence to his claim.

But the Northerners claim their own Deliverer: the Warded Man, a dark, forbidding figure.

Once, the Shar''Dama Ka and the Warded Man were friends. Now they are fierce adversaries. Yet as old allegiances are tested and fresh alliances forged, all are unaware of the appearance of a new breed of demon, more intelligent�and deadly�than any that have come before.',
     579, N'2010-04-13T00:00:00', 4);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 7)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (7, 9780345503824, N'The Daylight War',
     N'On the night of the new moon, the demons rise in force, seeking the deaths of two men both of whom have the potential to become the fabled Deliverer, the man prophesied to reunite the scattered remnants of humanity in a final push to destroy the demon corelings once and for all.

Arlen Bales was once an ordinary man, but now he has become something more�the Warded Man, tattooed with eldritch wards so powerful they make him a match for any demon. Arlen denies he is the Deliverer at every turn, but the more he tries to be one with the common folk, the more fervently they believe. Many would follow him, but Arlen�s path threatens to lead him to a dark place he alone can travel to, and from which there may be no returning.

The only one with hope of keeping Arlen in the world of men, or joining him in his descent into the world of demons, is Renna Tanner, a fierce young woman in danger of losing herself to the power of demon magic.

Ahmann Jardir has forged the warlike desert tribes of Krasia into a demon-killing army and proclaimed himself Shar�Dama Ka, the Deliverer. He carries ancient weapons--a spear and a crown--that give credence to his claim, and already vast swaths of the green lands bow to his control.

But Jardir did not come to power on his own. His rise was engineered by his First Wife, Inevera, a cunning and powerful priestess whose formidable demon bone magic gives her the ability to glimpse the future. Inevera�s motives and past are shrouded in mystery, and even Jardir does not entirely trust her.

Once Arlen and Jardir were as close as brothers. Now they are the bitterest of rivals. As humanity�s enemies rise, the only two men capable of defeating them are divided against each other by the most deadly demons of all--those lurking in the human heart.',
     639, N'2013-02-12T00:00:00', 3);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 8)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (8, 9780345531483, N'The Skull Throne',
     N'The Skull Throne of Krasia stands empty.

Built from the skulls of fallen generals and demon princes, it is a seat of honor and ancient, powerful magic, keeping the demon corelings at bay. From atop the throne, Ahmann Jardir was meant to conquer the known world, forging its isolated peoples into a unified army to rise up and end the demon war once and for all.

But Arlen Bales, the Warded Man, stood against this course, challenging Jardir to a duel he could not in honor refuse. Rather than risk defeat, Arlen cast them both from a precipice, leaving the world without a savior, and opening a struggle for succession that threatens to tear the Free Cities of Thesa apart.

In the south, Inevera, Jardir�s first wife, must find a way to keep their sons from killing each other and plunging their people into civil war as they strive for glory enough to make a claim on the throne.

In the north, Leesha Paper and Rojer Inn struggle to forge an alliance between the duchies of Angiers and Miln against the Krasians before it is too late.

Caught in the crossfire is the duchy of Lakton--rich and unprotected, ripe for conquest.

All the while, the corelings have been growing stronger, and without Arlen and Jardir there may be none strong enough to stop them. Only Renna Bales may know more about the fate of the missing men, but she, too, has disappeared...',
     681, N'2015-03-31T00:00:00', 4);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 9)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (9, 9780345531506, N'The Core',
     N'For time out of mind, bloodthirsty demons have stalked the night, culling the human race to scattered remnants dependent on half-forgotten magics to protect them. Then two heroes arose�men as close as brothers, yet divided by bitter betrayal. Arlen Bales became known as the Warded Man, tattooed head to toe with powerful magic symbols that enable him to fight demons in hand-to-hand combat�and emerge victorious. Jardir, armed with magically warded weapons, called himself the Deliverer, a figure prophesied to unite humanity and lead them to triumph in Sharak Ka�the final war against demonkind.

But in their efforts to bring the war to the demons, Arlen and Jardir have set something in motion that may prove the end of everything they hold dear�a Swarm. Now the war is at hand and humanity cannot hope to win it unless Arlen and Jardir, with the help of Arlen�s wife, Renna, can bend a captured demon prince to their will and force the devious creature to lead them to the Core, where the Mother of Demons breeds an inexhaustible army.

Trusting their closest confidantes, Leesha, Inevera, Ragen and Elissa, to rally the fractious people of the Free Cities and lead them against the Swarm, Arlen, Renna, and Jardir set out on a desperate quest into the darkest depths of evil�from which none of them expects to return alive.',
     781, N'2017-10-03T00:00:00', 4);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 10)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (10, 9780992580209, N'The Shadow of What Was Lost',
     N'It has been twenty years since the end of the war. The dictatorial Augurs�once thought of almost as gods�were overthrown and wiped out during the conflict, their much-feared powers mysteriously failing them. Those who had ruled under them, men and women with a lesser ability known as the Gift, avoided the Augurs'' fate only by submitting themselves to the rebellion''s Four Tenets. A representation of these laws is now written into the flesh of any who use the Gift, forcing those so marked into absolute obedience.

As a student of the Gifted, Davian suffers the consequences of a war fought�and lost�before he was born. Despised by most beyond the school walls, he and those around him are all but prisoners as they attempt to learn control of the Gift. Worse, as Davian struggles with his lessons, he knows that there is further to fall if he cannot pass his final tests.

But when Davian discovers he has the ability to wield the forbidden power of the Augurs, he sets into motion a chain of events that will change everything. To the north, an ancient enemy long thought defeated begins to stir. And to the west, a young man whose fate is intertwined with Davian�s wakes up in the forest, covered in blood and with no memory of who he is�',
     602, N'2014-09-04T00:00:00', 5);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 11)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (11, 9780316274111, N'An Echo of Things to Come',
     N'In the wake of the devastating attack on Ilin Illan, an amnesty has been declared for all Augurs - finally allowing them to emerge from hiding and openly oppose the dark forces massing against Andarra. However as Davian and his new allies hurry north toward the ever-weakening Boundary, fresh horrors along their path suggest that their reprieve may have come far too late.
In the capital, Wirr is forced to contend with assassins and an increasingly hostile Administration as he controversially assumes the mantle of Northwarden, uncovering a mystery that draws into question everything commonly believed about the rebellion his father led twenty years ago. Meanwhile, Asha begins a secret investigation into the disappearance of the Shadows, determined to discover not only where they went but the origin of the Vessels that created them - and, ultimately, a cure.
And with time against him as he races to fulfill the treacherous bargain with the Lyth, Caeden continues to wrestle with the impossibly heavy burdens of his past. Yet as more and more of his memories return, he begins to realise that the motivations of the two sides in this ancient war may not be as clear-cut as they first seemed...',
     752, N'2017-09-22T00:00:00', 6);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 12)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (12, 9780356507835, N'The Light of All That Falls',
     N'The Light of All That Falls concludes the epic adventure that began in The Shadow of What Was Lost, the acclaimed fantasy blockbuster from James Islington.

The Boundary is whole once again, but it may be too late.

Banes now stalk Andarra, while in Ilin Illan, the political machinations of a generation come to a head as Wirr''s newfound ability forces his family''s old enemies into action.

Imprisoned and alone in a strange land, Davian is pitted against the remaining Venerate as they work tirelessly to undo Asha''s sacrifice - even as he struggles with what he has learned about the friend he chose to set free.

And Caeden, now facing the consequences of his centuries-old plan, must finally confront its reality - heartbroken at how it began, and devastated by how it must end.',
     864, N'2019-12-12T00:00:00', 6);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[book] WHERE id = 13)
BEGIN
    INSERT INTO [dbo].[book]
    (
        [id],
        [isbn],
        [title],
        [description],
        [total_pages],
        [published_date],
        [publisher_id]
    )
    VALUES
    (13, 9780345430373, N'Dante''s Equation',
     N'In a breathless thriller that explores the relationship between science and the divine, good and evil, space and time, Jane Jensen takes us from the world we know into a reality we could only scarcely imagine. Until now.

Rabbi Aharon Handalman�s expertise with Torah code�rearranging words and letters in the Bible�has uncovered a man�s name. Who is Yosef Kobinski, and why did God hide his name in His sacred text? To find the answers, Aharon begins an investigation, and discovers that Kobinski, a Polish rabbi, was not only a mystic but also a brilliant physicist who authored what may be the most important lost work in human history.

In Seattle, Jill Talcott�s work with energy wave equations is being linked to Yosef Kobinski, now deceased, who claimed nearly fifty years ago that he discovered an actual physical law of good and evil. But when Jill�s lab explodes, she is forced to flee for her life, realizing that her cutting-edge research is far more dangerous than she ever has imagined. And that powerful people have a stake in what she may have uncovered.

Now Jill, her research partner, and a writer fascinated by Kobinski are about to meet Handalman in Poland�all four desperate to solve the astonishing riddle. Searching through the past, they trace Kobinski to a clearing in the woods near Auschwitz. And in that clearing they come face-to-face with the inexplicable: that Kobinski, drawing on his own alchemy of science and the Kabbalah, made himself vanish from the death camp in a blaze of fire. Now, with intelligence agents hot on their trail, the investigators have no choice. They must follow Kobinski �to wherever he may have gone. . . ',
     496, N'2003-07-29T00:00:00', 4);
END;

SET IDENTITY_INSERT [dbo].[book] OFF;