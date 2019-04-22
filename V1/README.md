# Inequalities

## Task Description

You are given a set of inequalities. Each of the inequalities refers to the variable X. Determine the maximum subset of the given set which has a solution.  

The input file `inequalities.in` will contain a list of at most 50 inequalities, one inequality per line. Each inequality is given in one of the following forms: “X < C”, “X <= C”, “X = C”, “X > C” or “X >= C” where C is some integer constant (possibly different for different inequalities). The input data will be correct and it is not required to check it explicitly.

On the first line of the output file `inequalities.out` print the integer K: the maximum number of inequalities that can be satisfied simultaneously. On the following K lines print the found set of inequalities, one inequality per line, regardless of their order.

### Sample input

X >= 3

X < 5

X < 6

X >= 3

X = 100

X < 3

X > 3

X <= -1

The Input is **the path to the file `inequalities.in.txt`**.

### Sample output

5

X >= 3

X < 5

X < 6

X >= 3

X > 3

The Output should be in the console and in the `inequalities.out.txt` file.

**Explanation:** These five inequalities are satisfied if X = 4. No greater subset has a solution. 

## Sources that helped me

* https://docs.microsoft.com/en-us/dotnet/api/system.string.replace?view=netframework-4.8
* https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=netframework-4.8
* https://stackoverflow.com/questions/2695444/clearing-content-of-text-file-using-c-sharp
* https://stackoverflow.com/questions/390491/how-to-add-item-to-the-beginning-of-listt
