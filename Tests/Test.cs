using System;
using MF;
using Xunit;

namespace Tests
{

    public class Test
    {
        private readonly Utility _utility;

        public Test() {
            _utility = new Utility();
        }

        [Fact]
        public void ShouldReturnEmptyResul_When_Input_Is_Null()
        {
            string input = null;

            var repeatedWords = _utility.RepeatedWords(input);

            Assert.Empty(repeatedWords);

        }

        [Fact]
        public void ShouldReturnEmptyResul_When_Input_Is_Empty()
        {
            var input = string.Empty;

            var repeatedWords = _utility.RepeatedWords(input);

            Assert.Empty(repeatedWords);

        }

        [Fact]
        public void CanFindDuplicateWordsArray_From_Paragraph()
        {
           
            var input = @"In a village of La Mancha, the name of which I have
                            no desire to call to
                            mind, there lived not long since one of those gentlemen that keep a lance
                            in the lance-rack, an old buckler, a lean hack, and a greyhound for
                            coursing.An olla of rather more beef than mutton, a salad on most
                            nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra
                            on Sundays, made away with three - quarters of his income.";

            var repeatedWords = _utility.RepeatedWords(input);

            Assert.True(repeatedWords.Length == 3, $"Repeated words are: {repeatedWords[0]}, {repeatedWords[1]}, {repeatedWords[2]}");

        }
        [Fact]
        public void CanFindDuplicateWordsArray_From_Sentence()
        { 
            var input = @"e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e";

            var repeatedWords = _utility.RepeatedWords(input);
            Assert.True(repeatedWords.Length == 3, $"Repeated words are: {repeatedWords[0]}, {repeatedWords[1]}, {repeatedWords[2]}");

        }

        [Fact]
        public void CanFindDuplicateWordsArray_With_Punctuation()
        {
            var input = @" //wont won't won't";

            var repeatedWords = _utility.RepeatedWords(input);
            Assert.True(repeatedWords.Length == 2, $"Repeated words are: {repeatedWords[0]}, {repeatedWords[1]}");

        }

        [Fact]
        public void ReturnDuplicateWordsByDescending()
        {
            const string expectedWord1 = "won't";
            const string expectedWord2 = "wont";

            var input = @" //wont won't won't";
            
            var repeatedWords = _utility.RepeatedWords(input);
            Assert.True(repeatedWords[0] == expectedWord1 && repeatedWords[1] == expectedWord2, $"Order by descending, {repeatedWords[0]}, {repeatedWords[1]}");

        }

        [Fact]
        public void CanFindDuplicateWordsArray_With_TieBreak_Alphabet_sort()
        {
            const string expectedWord1 = "apple";
            const string expectedWord2 = "door";
            var input = @" //apple door book, door, apple";

            var repeatedWords = _utility.RepeatedWords(input);
            Assert.True(repeatedWords[0] == expectedWord1 && repeatedWords[1] == expectedWord2, $"Tie Break alphabet sort, {repeatedWords[0]}, {repeatedWords[1]}");

        }

        [Fact]
        public void CanFindDuplicateWords_Remove_MultipleSpaces()
        {
            const string expectedWord1 = "apple";
            const string expectedWord2 = "door";
            var input = @" //apple door    book, door, apple";

            var repeatedWords = _utility.RepeatedWords(input);
            Assert.True(repeatedWords[0] == expectedWord1 && repeatedWords[1] == expectedWord2, $"Tie Break alphabet sort, {repeatedWords[0]}, {repeatedWords[1]}");

        }
    }
}
