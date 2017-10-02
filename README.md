# DiceRoll_Solution

###### Part 1: Complete the RollDie() Method
The completed method:
```
private static int RollDie()
{
	//set up a return value
	int returnValue = 0;

	//seed the random function to ensure randomness
	Random rnd = new Random(Guid.NewGuid().GetHashCode());

	//populate the returnvalue
	returnValue = rnd.Next(1, 7);

	//return the new random integer value
	return returnValue;
 }
 ```
 
 If you started by declaring the random variable like this:
 
 ```Random rnd = new Random();```
 
You probably noticed that your results weren't very random. This is because the random function uses the computers clock to "seed" it's random number. This means to random variables delcared microseconds from each other will most likely be the same. The problem is easily fixed by just seeding the random with something that guarentees its random. The GUID (guaranteed unique id) returns a random 37 character string that looks something like ``{20380a36-8777-43f7-a79e-65bdb53f4621}``. The GUID is guaranteed to be unique within 4 billion instances. Then we call the ``GetHashCode()`` method which converts the GUID into an integer that we can use to seed the random method.

###### Part 2: Fix the logic bug
In our message to the user we tell them to press enter to roll again or to press q to quit. In the while statement our condition is wrong. It reads "while the user input is anything but q" quit the application. We need to change the ``==`` to ``!=`` (equal to not equal). The completed while loop should look like this:

```
do
{
    Console.WriteLine("Dice 1 rolled a: {0}", RollDie());
    Console.WriteLine("Dice 2 rolled a: {0}", RollDie());
    Console.WriteLine("Press enter to roll again or type q for quit");

} while (Console.ReadLine() != "q");
```

###### Scoring the Bonus points
These will be broken out into branches MoreInteractive1, MoreInteractive2, and MoreInteractive3

##### Branch: MoreInteractive1
After looking at our application I realized it needed a little more pizazz, time to break out the old ASCII art skills. I figured I could make something from just text that looked like a close approximation of a die.
Each dice would have three lines. I used brackets for the sides and a lowercase “o” for the pip. The one would look something like:
```
[          ]
[     o    ]
[          ]
```
Using that as an example I created a dictionary (integer and string) to hold my dice. The dictionary looks like the following code:
```
var die = new Dictionary<int, string>
{
    { 1, "[     ]\n[  o  ]\n[     ]" },
    { 2, "[     ]\n[ o o ]\n[     ]" },
    { 3, "[  o  ]\n[ o o ]\n[     ]" },
    { 4, "[ o o ]\n[     ]\n[ o o ]" },
    { 5, "[ o o ]\n[  o  ]\n[ o o ]" },
    { 6, "[ o o ]\n[ o o ]\n[ o o ]" },
};
```
Keep in mind that the ``\n`` produces a new line. Now I had a variable that contained a graphical representation of all 6 dice all I need was a way to pull two of them out at random. This time it was LINQ to the rescue. I used the orderby statement with a giud to reorder the whole list randomly and then just grab the top 2 dice from the list.
```
var shuffled = die.OrderBy(x => Guid.NewGuid()).Take(2);
foreach (KeyValuePair<int, string> i in shuffled)
{
    Console.WriteLine(i.Value);
    Console.WriteLine();
}
Console.WriteLine("Press enter to roll again or type q for quit");
```

This is better, but they still don’t look too much like real dice. 

##### Branch: MoreInteractive2
I remembered from my old DOS days that there are some characters that were designed to draw boxes on a console screen. Per something I read online it looked like the first thing I needed to do was set the encoding for the console so I could get to these extra characters. So, I added the following line to the top of my program:

``` Console.OutputEncoding = System.Text.Encoding.UTF8;```

Then I could swap out my brackets and o’s with something that looked better:
```
var die = new Dictionary<int, string>
{
    { 1, "┌─────────┐\n│         │\n│    ○    │\n│         │\n└─────────┘" },
    { 2, "┌─────────┐\n│         │\n│  ○   ○  │\n│         │\n└─────────┘" },
    { 3, "┌─────────┐\n│    ○    │\n│  ○   ○  │\n│         │\n└─────────┘" },
    { 4, "┌─────────┐\n│  ○   ○  │\n│         │\n│  ○   ○  │\n└─────────┘" },
    { 5, "┌─────────┐\n│  ○   ○  │\n│    ○    │\n│  ○   ○  │\n└─────────┘" },
    { 6, "┌─────────┐\n│  ○   ○  │\n│  ○   ○  │\n│  ○   ○  │\n└─────────┘" },
};
```
Now I had something that looked a lot more like actual dice.

##### Branch: MoreInteractive3
It was time to see if I could make it even better. For one thing, I wanted to put both the dice together instead of on top of each other and I wanted to hear dice rolling before the dice were displayed. I also realized something else after looking at my dictionary there were only a few strings needed to make up each dice. I decided to refactor my code and change the way my dictionary was created. So now my code looked something like:
```
string top = "┌───────────┐";
string zero = "│           │";
string one = "│     ○     │";
string two = "│  ○     ○  │";
string bottom = "└───────────┘";

string[] dieFace1 = { top, zero, zero, one, zero, zero, bottom };
string[] dieFace2 = { top, zero, zero, two, zero, zero, bottom };
string[] dieFace3 = { top, zero, one, zero, two, zero, bottom };
string[] dieFace4 = { top, zero, two, zero, two, zero, bottom };
string[] dieFace5 = { top, zero, two, one, two, zero, bottom };
string[] dieFace6 = { top, zero, two, two, two, zero, bottom };

var die = new Dictionary<int, string[]>
{
    {1, dieFace1},
    {2, dieFace2},
    {3, dieFace3},
    {4, dieFace4},
    {5, dieFace5},
    {6, dieFace6},
};
```
I needed each part (top, bottom, middle) of the dice to be created without line breaks since I was going to place both dice next to each other horizontally. This change would also make it easy for me to change how the dice looked in the future since all I’d need to do is alter the top, zero, one, two and bottom variables.






