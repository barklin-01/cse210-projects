using System;
using System.Collections.Generic;

public enum ScriptureSource
{
    Bible,
    BookOfMormon
}

public class ScriptureLibrary
{
    private List<Scripture> _bibleScriptures;
    private List<Scripture> _bomScriptures;
    private Random _rand;

    public ScriptureLibrary()
    {
        _rand = new Random();
        // Added extra Bible scriptures for more variety in random selection
        // Bible scriptures
        _bibleScriptures = new List<Scripture>()
        {
            new Scripture(new Reference("Isaiah", 55, "6-8"),
                "Seek ye the Lord while he may be found, call ye upon him while he is near: Let the wicked forsake his way, and the unrighteous man his thoughts: and let him return unto the Lord, and he will have mercy upon him; and to our God, for he will abundantly pardon. For my thoughts are not your thoughts, neither are your ways my ways, saith the Lord."),

            new Scripture(new Reference("Ezekiel", 18, "30"),
                "Therefore I will judge you, O house of Israel, every one according to his ways, saith the Lord God. Repent, and turn yourselves from all your transgressions; so iniquity shall not be your ruin."),

            new Scripture(new Reference("Romans", 15, "13"),
                "Now the God of hope fill you with all joy and peace in believing, that ye may abound in hope, through the power of the Holy Ghost."),

            new Scripture(new Reference("John", 14, "6"),
                "Jesus saith unto him, I am the way, the truth, and the life: no man cometh unto the Father, but by me.")
        };

        // I added verses from the Book of Mormon so the user can choose between the Bible and the Book of Mormon.
        // Book of Mormon scriptures
        _bomScriptures = new List<Scripture>()
        {
            new Scripture(new Reference("1 Nephi", 8, "12"),
                "And as I partook of the fruit thereof it filled my soul with exceedingly great joy; wherefore, I began to be desirous that my family should partake of it also; for I knew that it was desirable above all other fruit."),

            new Scripture(new Reference("3 Nephi", 27, "20"),
                "Now this is the commandment: Repent, all ye ends of the earth, and come unto me and be baptized in my name, that ye may be sanctified by the reception of the Holy Ghost, that ye may stand spotless before me at the last day."),

            new Scripture(new Reference("Alma", 26, "22"),
                "Yea, he that repenteth and exerciseth faith, and bringeth forth good works, and prayeth continually without ceasing—unto such it is given to know the mysteries of God; yea, unto such it shall be given to reveal things which never have been revealed; yea, and it shall be given unto such to bring thousands of souls to repentance, even as it has been given unto us to bring these our brethren to repentance."),

            // Some extras for variety
            new Scripture(new Reference("1 Nephi", 3, "7"),
                "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),

            new Scripture(new Reference("Alma", 37, "6"),
                "Now ye may suppose that this is foolishness in me; but behold I say unto you, that by small and simple things are great things brought to pass; and small means in many instances doth confound the wise."),

            new Scripture(new Reference("Ether", 12, "27"),
                "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them."),

            new Scripture(new Reference("Mosiah", 2, "17"),
                "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God.")
        };
    }

    public Scripture GetRandomScripture(ScriptureSource source)
    {
        if (source == ScriptureSource.Bible)
        {
            int index = _rand.Next(_bibleScriptures.Count);
            return _bibleScriptures[index];
        }
        else
        {
            int index = _rand.Next(_bomScriptures.Count);
            return _bomScriptures[index];
        }
    }
}