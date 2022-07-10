using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatastructureDemo130Batch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nPlease choose program number to execute");
            Console.WriteLine("1:LinkedList\n2:Stack\n3:Queue\n4:Exit\n5:Stack Using LinkedList\n6:BinarySearchTree\n7:SortedLinkedList\n8:HashTable");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                //case 1:

                //    CustomLinkedList linkedList = new CustomLinkedList();
                //    linkedList.AddAtLast(56);
                //    linkedList.AddAtLast(30);
                //    linkedList.AddAtLast(70);
                //    linkedList.Display();
                //Console.WriteLine("{0} is deleted from linkedlist", linkedList.DeleteLastNode());
                //    //linkedList.Display();
                //    Console.WriteLine("{0} is present", linkedList.Search(30));
                //    break;
                //case 2:
                //    LinkedListStack stack = new LinkedListStack();
                //    stack.Push(70);
                //    stack.Push(30);
                //    stack.Push(56);
                //    stack.Display();
                //    //stack.Peek();
                //    //stack.Pop();
                //    Console.WriteLine("Is stack empty? {0}", stack.isEmpty());
                //    stack.Display();

                //    break;
                //case 3:
                //    LinkedListQueue queue = new LinkedListQueue();
                //    queue.Enqueue(56);
                //    queue.Enqueue(30);
                //    queue.Enqueue(70);
                //    queue.Display();
                //    queue.Dequeue();
                //    queue.Display();
                //    break;
                //case 5:
                //    LinkedListStack customStack = new LinkedListStack();
                //    customStack.PushByLinkedList(70);
                //    customStack.PushByLinkedList(30);
                //    customStack.PushByLinkedList(56);
                //    customStack.DisplayByLinkedList();
                //    break;
                //case 7:
                //    SortedLinkedList<int> sorted = new SortedLinkedList<int>();
                //    sorted.SortedAdd(56);
                //    sorted.SortedAdd(30);
                //    sorted.SortedAdd(40);
                //    sorted.SortedAdd(70);
                //    sorted.Display();
                //    break;
                case 8:
                    string paragraph = "To be or not to be";
                    CountNumbOfOccurence(paragraph);//going to CountNumbOdoccuranec method
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }

        public static void CountNumbOfOccurence(string paragraph)
        {
            MyMapNode<string, int> hashTabe = new MyMapNode<string, int>(6);//creating hashtable of size 6

            string[] words = paragraph.Split(' ');//splitiong string with space

            foreach (string word in words)//travese each word
            {
                if (hashTabe.Exists(word.ToLower()))//if that wrod inside that hashtable word exist convert to lower
                    hashTabe.Add(word.ToLower(), hashTabe.Get(word.ToLower()) + 1);
                else
                    hashTabe.Add(word.ToLower(), 1); //to,1 //now added to,1 to linked list
            }
            Console.WriteLine("Displaying after add operation");
            hashTabe.Display();//display
            string s = "or";
            hashTabe.Remove(s);//here we are removing for the word or
            Console.WriteLine("After removed an item {0}", s);
            hashTabe.Display();
        }
    }
}