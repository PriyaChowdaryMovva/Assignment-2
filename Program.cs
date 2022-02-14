/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is: {0}", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {

            try
            {
                ArrayList li = new ArrayList();
                int min = 0, max = nums.Length - 1, mid;
                int flag = 1;
                for (mid = (min + max) / 2; min <= max; mid = (min + max) / 2)
                {
                    if (nums[mid] == target) //checking if the middle element in the sorted array is equal to the target number
                    {
                        flag = 0;
                        return mid; //return index of target number to main program
                    }
                    else if (nums[mid] > target) //if middle element in the sorted array is greater than the target number
                    {
                        max = mid - 1; //update max
                    }
                    else //if middle element in the sorted array is lesser than the target number
                        min = mid + 1; //update min
                }
                if (flag == 1) //if target not present in the given array
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        li.Add(nums[i]); //converting the given array into a list
                    }
                    li.Add(target); //adding the target element to the list
                    li.Sort(); //sorting the list
                }
                return li.IndexOf(target); //returning the index of target where it would be if it were inserted in order
            }
            catch (Exception)
            {
                throw;
            }


        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                int count;
                string str = "";
                Dictionary<string, int> dictionary = new Dictionary<string, int>();

                paragraph = paragraph
                 .Replace("!", "")
                 .Replace("?", "")
                 .Replace("'", "")
                 .Replace(", ", " ")
                 .Replace(",", " ")
                 .Replace(".", "")
                 .Replace(";", "")
                 .ToLower(); //Removing punctuations and converting the paragraph to lowercase
                string[] arr = paragraph.Split(' '); //Create an array of words from the given paragraph

                foreach (string word in arr) //looping over each word in the string array 
                {
                    if (dictionary.ContainsKey(word)) //if the word is present in the dictionary
                        dictionary[word] = dictionary[word] + 1; //Increment its corresponding value
                    else
                        dictionary[word] = 1; //if the word is not present in the dictionary,add it into the dictionary with a value 1
                }

                var myList = dictionary.ToList(); //converting the dictionary to a list

                myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value)); //Sorting the list by value

                if (banned.Length != 0)
                {
                    for (int i = myList.Count - 1; i >= 0; i--) //reverse iterating to fetch the most frequent word first
                    {
                        count = 0;

                        for (int j = 0; j < banned.Length; j++)
                        {
                            if (myList[i].Key == banned[j]) //if the word is present in the banned list
                            {
                                count++; // increment counter
                            }
                        }
                        if (count < 1)//  if the most occured word is not found in the banned array
                        {
                            str = myList[i].Key; //assign the word to str
                            break;
                        }
                    }
                }
                else //if the banned array is empty
                {
                    return myList[myList.Count - 1].Key; //returns the last element in the sorted list
                }
                return str;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                var d = new Dictionary<int, int>(); //creating a dictionary to store the array elements as keys and their frequencies as corresponding values
                foreach (var num in arr)
                {
                    if (d.ContainsKey(num)) // if array element is already present as key in the dictionary d
                    {
                        d[num] = d[num] + 1; //increment its frequency
                    }
                    else // if array element is not present as key in the dictionary d
                    {
                        d.Add(num, 1); //add the array element as key to the dictionary
                    }
                }
                int res = -1; //default return value 
                foreach (var num in arr)
                {
                    if (d[num] == num && num > res) //if lucky number and greater than the default value
                    {
                        res = num; //getting the greatest lucky number
                    }
                }
                return res; //returning lucky number to the main program 
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int count = 0; //bulls counter
                int count1 = 0; //cows counter
                if (secret == guess) //if secret = guess
                {
                    string res = secret.Length + "A" + 0 + "B"; //bulls = no.of characters in secret/guess
                    return res;
                }
                for (int i = 0; i < secret.Length; i++) //loop to check for bulls
                {
                    if (secret[i] == guess[i]) //if bull
                    {
                        count++; //incerement bull counter
                        secret = secret.Remove(i, 1); //remove the found char from secret
                        guess = guess.Remove(i, 1); //remove the found char from secret
                        i--;
                    }
                }
                for (int i = 0; i < secret.Length; i++) //loop through string secret to check for cows 
                {
                    for (int j = 0; j < guess.Length; j++) //loop through string guess to check for cows 
                    {
                        if (secret[i] == guess[j]) //if cow
                        {
                            count1++; //increment cows counter
                            secret = secret.Remove(i, 1);
                            guess = guess.Remove(j, 1);
                            i--;
                            break;
                        }
                    }
                }

                string ans = count + "A" + count1 + "B";
                return ans;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int j = 0, stop = 0;
                int[] arr = new int[30];
                for (int i = 0; i < s.Length; i++)
                {
                    arr[s[i] - 'a'] = i; //converting char value to numeric and storing it in the array
                }

                List<int> ans = new List<int>();
                for (int i = 0; i < s.Length; i++)
                {
                    j = Math.Max(j, arr[s[i] - 'a']); //finding last occurance of the char 
                    if (i == j)
                    {
                        ans.Add(i - stop + 1); // calculating the partition width and storing it in the list ans
                        stop = i + 1; //update stop
                    }
                }
                return ans;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                char[] arr = s.ToCharArray();
                if (s.Length == 0) //if string is empty
                {
                    return new List<int> { 0, 0 };
                }
                int space = 0;
                int line = 1; //if the string is not empty, by default there is atleast 1 line
                foreach (char c in arr) //checking for width of each char 
                {
                    if (space + widths[c - 'a'] > 100) //if width > 100
                    {
                        line += 1; //move to the next line
                        space = widths[c - 'a']; //update char width in the current line 
                    }
                    else if (space + widths[c - 'a'] == 100) //if width = 100
                    {
                        line += 1; //move to the next line
                        space = 0; //update width to zero of the new line
                    }
                    else ////if width < 100
                    {
                        space += widths[c - 'a']; //update char width in the current line 
                    }
                }
                if (space == 0) //if new empty line 
                {
                    return new List<int> { line - 1, 100 }; //return previous line with full width capacity
                }
                return new List<int> { line, space };

            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                Dictionary<char, char> d = new Dictionary<char, char>(); //creating a dictionary to store matching parenthesis as key value pairs
                d.Add('}', '{');
                d.Add(')', '(');
                d.Add(']', '[');

                int count = 0;
                Stack<char> myStack = new Stack<char>(); //creating a stack to save opening parenthesis
                while (count < bulls_string10.Length)
                {
                    if (d.ContainsKey(bulls_string10[count])) //checking for closing parenthesis
                    {
                        if (myStack.Count == 0) return false; // if stack is empty implies no corresponding opening parentheis, hence return false
                        if (d[bulls_string10[count]] != myStack.Pop()) // if key of the closing parentheis does not match the top element of the stack, it is not the right pair, hence return false
                            return false;
                    }
                    else
                        myStack.Push(bulls_string10[count]); //if opening parenthesis, then push it into the stack

                    count++;
                }
                if (myStack.Count == 0) //if stack is empty, implies all matching parenthesis were found
                    return true;
                else
                    return false; //if stack is not empty, implies all opening parenthesis do not have corresponding closing parenthesis

            }
            catch (Exception)
            {
                throw;
            }
        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {

                string[] morseCode = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                char[] alphabets = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                Dictionary<char, string> d = new Dictionary<char, string>();
                HashSet<string> hash = new HashSet<string>(); //declaring a hashset to store unique transformed words
                int count = 0;
                for (int i = 0; i < alphabets.Length; i++) //creating the dictionary with all English alphabets as keys and their corresponding Morse code as values
                {
                    d.Add(alphabets[i], morseCode[i]);
                }
                foreach (string w in words) //for each word in the given string 
                {
                    string temp = ""; //creating a temporary string to hold the transformed Morse code of a word
                    foreach (char ch in w.ToCharArray())
                    {
                        temp += d[ch]; //getting the Morse code value from the dictionary for every character in the word
                    }
                    if (!hash.Contains(temp)) //checking if the transformed word is already present in the hash table
                    {
                        hash.Add(temp); //if transformed word is not present in the hastable, then add it to the hashtable
                        count++; //increment counter
                    }
                }
                return count; //return count of unique values in the hash table

            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                int length1 = word1.Length;
                int length2 = word2.Length;


                int[,] distance = new int[length1 + 1, length2 + 1]; ////distance[i,j] is the distance travelled from word1(1-ith) to word2(1-jth)
                for (int j = 0; j <= length2; j++)
                {
                    distance[0, j] = j; //delete all characters in word2
                }
                for (int i = 0; i <= length1; i++)
                {
                    distance[i, 0] = i;
                }

                for (int i = 1; i <= length1; i++)
                {
                    for (int j = 1; j <= length2; j++)
                    {

                        if (word1[i - 1] == word2[j - 1]) // comparing if the element in word1 and word2 are same
                        {
                            distance[i, j] = distance[i - 1, j - 1]; //if its similar then move to the previous element to check.
                        }
                        else
                        {
                            distance[i, j] = Math.Min(Math.Min(distance[i, j - 1], distance[i - 1, j]), distance[i - 1, j - 1]) + 1; //if its different,finding least number of operations that can be performed. 
                        }
                    }
                }
                return distance[length1, length2]; //return the least number of operations performed


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
