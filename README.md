# PyramidPath
Finds the maximum path in the pyramid using Dynamic Programming approach. The tree is resolved iteratively, level by level and the results are saved in the helping binary tree, which stores partial solutions for each consequent row.

Note:
If only the sum of the best path would be needed, one could only store onle line of the tree in the memory, thus reducing storage complexity.

Storage complexity: O(n)

Computational complexity: O(n)

Computational complexity is optimal (best possible) because any algorithm would need to process the full input to find a path.

# Sample output
Max sum: 8186

Path: 215->192->269->836->805->728->433->528->863->632->931->778->413->310->253
