<h1>Task 1</h1>

Implement methods in Processor class.

<h1>Task 2</h1>

Given an array, for example, {1,2,3,3,6,6} return minimum number of iterations (adding or substracting one each time) necessary to have an array that every item is different.
Solution: {1,2,3,4,5,6} -> 2 movements (3+1 = 4, 6-1 = 5)

<h1>Task 3</h1>
Given two arrays A and B, return the number of different times there is an index that, splitting those arrays by the same index, the sum of the items contained in each subarray is the same.

<h2>Example: </h2>
A { 0, 4, -1, 0, 3 };
B { 0, -2, 5, 0, 3 };

<p>There are two solutions:</p>

<p>Index = 2</p>
<ul>
    <li>A1 = 0 + 4 + -1 = 3</li> 
    <li>A2 = 0 + 3 = 3</li>
    <li>B1 = 0 + -2 + 5 = 3</li>
    <li>B2 = 0 + 3 = 3</li>
</ul>
<p>Index = 5</p>
<ul>
    <li>A1 = 0 + 4 + -1 + 0 = 3</li>
    <li>A2 = 3</li>
    <li>B1 = 0 + -2 + 5 + 0 = 3</li>
    <li>B2 = 3</li>
</ul>