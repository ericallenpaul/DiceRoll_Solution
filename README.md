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
 
        


