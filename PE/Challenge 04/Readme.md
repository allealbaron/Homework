Background
We are given directions to go from one point to another. The directions are "NORTE", "SUR", "OESTE", "ESTE". Clearly "NORTE" and "SUR" are opposite, "OESTE" and "ESTE" too. Going one direction and coming back the opposite direction is a wasted effort, so let's concise these directions to go the shortest route.

For example, given the following directions:

String[] plan = { "NORTE", "SUR", "SUR", "ESTE", "OESTE", "NORTE", "OESTE" };
You can immediately see that going "NORTE" and then "SUR" is not reasonable, better stay to the same place!
So the task is to reduce a simplified version of the plan. A better plan in this case is simply:

String[] plan = { "OESTE" };
Other examples:
In ["NORTE", "SUR", "ESTE", "OESTE"], the direction "NORTE" + "SUR" is going NORTE and coming back right away. What a waste of time! Better to do nothing. The path becomes ["ESTE", "OESTE"], now "ESTE" and "OESTE" annihilate each other, therefore, the final result is [].
In ["NORTE", "ESTE", "OESTE", "SUR", "OESTE", "OESTE"], "NORTE" and "SUR" are not directly opposite but they become directly opposite after the reduction of "ESTE" and "OESTE" so the whole path is reducible to ["OESTE", "OESTE"].

Task
You have to write a function dirReduc which will take an array of strings and returns an array of strings with the needless directions removed (W<->E or S<->N
side by side).

Specification
Challenge.DirReduc(arr)
Parameters
arr: string[] - An array with each index containing 1 of the 4 cardinal directions, all in uppercase

Return Value
string[] - The optimized set of instructions

Examples
arr	Return Value
["NORTE","SUR","SUR","ESTE","OESTE","NORTE","OESTE"]	["OESTE"]
["NORTE","SUR","SUR","ESTE","OESTE","NORTE"]	[]
["NORTE","OESTE","SUR","ESTE"]	["NORTE","OESTE","SUR","ESTE"]
Note
Not all paths can be made simpler.

The path ["NORTE", "OESTE", "SUR", "ESTE"] is not reducible. "NORTE" and "OESTE", "OESTE" and "SUR", "SUR" and "ESTE" are not directly opposite of each other and can't become such. Hence the result path is itself : ["NORTE", "OESTE", "SUR", "ESTE"].
