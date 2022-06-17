namespace DesignPatterns.Structural
{
    class SentenceFlyweight
    {
        public class Sentence
        {
            private readonly string _plainText;
            private WordToken[] WordTokens;

            public Sentence(string plainText)
            {
                _plainText = plainText;
                var wordCount = GetWordCount();
                WordTokens = new WordToken[wordCount];
                for (int i = 0; i < wordCount; i++)
                {
                    WordTokens[i] = new WordToken();
                }
                
            }

            public WordToken this[int index]
            {
                get { return WordTokens[index]; }
            }

            private int GetWordCount()
            {
                return _plainText.Split(' ').Length;
            }

            public override string ToString()
            {
                var words = _plainText.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (this[i].Capitalize)
                    {
                        words[i]= words[i].ToUpper();
                    }
                }

                return string.Join(" ", words);
            }

            public class WordToken
            {
                public bool Capitalize;
            }
        }
    }
}
