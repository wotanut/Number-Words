using System;

namespace number_words
{
    class word
    {
            private string[] words = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            private string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            private string[] big_numbers = { "", "thousand", "million"};
        public word()
        {

        }
        public string get_word_from_number(int number)
        {
            string word = "";
            
            for (int i = 0; i < big_numbers.Length; i++)
            {
                if (number >= 1000)
                {
                    word = get_word_from_number(number / 1000) + " " + big_numbers[i] + " " + get_word_from_number(number % 1000);
                    return word;
                }
                else
                {
                    if (number >= 100)
                    {
                        word = words[number / 100] + " hundred " + get_word_from_number(number % 100);
                        return word;
                    }
                    else
                    {
                        if (number >= 20)
                        {
                            word = tens[number / 10] + " " + get_word_from_number(number % 10);
                            return word;
                        }
                        else
                        {
                            word = words[number];
                            return word;
                        }
                    }
                }
            }
            return word;
        }
        public int get_number_from_word(string input)
        {            
            string number = "";
            string[] word = input.Split(' ');
            for (int i = 0; i < word.Length; i++)
            {
                foreach(string s in big_numbers)
                {
                    if (word[i] == s)
                    {
                        number += s;
                    }
                }
                foreach(string s in tens)
                {
                    if (word[i] == s)
                    {
                        number += s;
                    }
                }
                foreach(string s in words)
                {
                    if (word[i] == s)
                    {
                        number += s;
                    }
                }
            }

            return Convert.ToInt32(word);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // get the user's input

            bool valid_input = false;
            string input = "";

            while (!valid_input)
            {
                Console.Write("Enter a number between 1 and 100,000: ");
                try {
                    input = Console.ReadLine();
                    valid_input = true;
                }
                catch{
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
            }
            word w = new word();
            try{
                Console.WriteLine(w.get_word_from_number(Convert.ToInt32(input)));
            }
            catch{
                try{
                    Console.WriteLine(w.get_number_from_word(input));
                }
                catch{
                    Console.WriteLine("Failed to convert input to number or word.");
                }
            }
        }
    }
}
