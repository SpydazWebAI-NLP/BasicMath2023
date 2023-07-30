**Trie Data Structure (TRYE)**

![Trie](trie_readme_image.jpg)

**Introduction**
The `TRYE` data structure represents a Trie, which is a type of tree used for efficient storage and retrieval of strings. It allows quick searches for strings by prefix, making it suitable for tasks like autocomplete suggestions, dictionary implementations, and word lookup operations.

**Features**
- The `TRYE` data structure supports storing individual characters as well as complete words.
- It provides methods to add strings to the Trie iteratively, character by character, word by word, or sentence by sentence.
- The Trie can be searched for the existence of a particular word.
- The `TRYE` data structure is designed to support various variable types, including booleans, integers, and strings, at each node.
- The Trie can be serialized and deserialized to/from JSON format.
- A TreeView representation of the Trie can be generated for visualization.

**Structure Members**
1. `Children`: Represents the child nodes of the current node in the Trie.
2. `NodeBool`: Used to store a boolean value for the current node.
3. `NodeBoolList`: Used to store a list of boolean values for the current node.
4. `NodeData`: Stores a character string used as an identifier for the node, usually representing the character associated with the edge leading to this node.
5. `NodeID`: An enumeration representing the ID of the node, specific to its level in the Trie.
6. `NodeInt`: Used to store an integer value for the current node.
7. `NodeIntList`: Used to store a list of integer values for the current node.
8. `NodeLevel`: Denotes the level of the node in the Trie.
9. `NodeStr`: Used to store a string value for the current node.
10. `NodeStrList`: Used to store a list of string values for the current node.

**Public Methods**
1. `AddItterativelyByCharacter`: Adds a string iteratively to the Trie character by character.
2. `AddItterativelyBySent`: Adds a string iteratively to the Trie by splitting the string into sentences.
3. `AddItterativelyByWord`: Adds a string iteratively to the Trie by splitting the string into words.
4. `AddStringbyChars`: Adds a string to the Trie character by character.
5. `AddStringbyWord`: Adds a string to the Trie by splitting the string into words.
6. `CheckWord`: Checks if a word (string) exists in the Trie.
7. `CountNodes`: Returns the total number of nodes in the Trie.
8. `CountWords`: Returns the number of words (nodes until a stop character is found) in the Trie.
9. `Depth`: Returns the depth (maximum level) of the Trie.
10. `FIND`: Searches for a given word in the Trie and returns true if found.
11. `ToView`: Returns a TreeViewControl representation of the Trie contents.

**Enum `CharID`**
- The enumeration `CharID` represents the unique IDs assigned to each character in the Trie.
- The `StopChar` ID (27) represents the end of a word in the Trie.

**Getting Started**
1. Create a Trie object using the `MakeTree` method. Optionally, you can provide a root node name.
2. Add strings to the Trie using the available methods (`AddItterativelyByCharacter`, `AddItterativelyBySent`, or `AddItterativelyByWord`).

**Example Usage**
```vb.net
Dim trieTree As TRYE = TRYE.MakeTree()
trieTree.AddItterativelyByWord("apple")
trieTree.AddItterativelyByWord("banana")
trieTree.AddItterativelyByWord("orange")

Console.WriteLine(trieTree.CheckWord("apple")) ' Output: True
Console.WriteLine(trieTree.CheckWord("grape")) ' Output: False
```

**Note**
- This `TRYE` data structure is written in VB.NET and provides basic Trie functionality.
- Feel free to use and modify this data structure as needed for your specific use cases.
- The code may be further optimized or extended for additional features if required.