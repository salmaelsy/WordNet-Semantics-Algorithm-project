## Wordnet semantics using C#
# What is Wordnet semantics?

## ${\color{blue}Terminologies \space and \space Usage}$  
 - The following table explains three main terminologies that will be used throughout the document
   
${\color{lightblue}WordNet}$          |  ${\color{lightblue}Synsets}$  | ${\color{lightblue} is-a \space relationship}$
:-------------------------:|:-------------------------:|:-------------------------:
WordNet is a semantic lexicon for the English language that computational linguists and cognitive scientists use extensively. For example, WordNet was a key component in IBM's Watson question-answering computer system.  |  Group of words that have the same meaning WordNet groups words into sets of synonyms (words that have the same meaning) called synsets. For example, { AND circuit, AND gate } is a synset that represents a logical gate that fires only when all of its inputs fire. | WordNet describes semantic relationships between synsets. One such relationship is the is-a relationship, which connects a hyponym (more specific synset, dealt with as a child) to a hypernym (more general synset as a parent). For example, the synset { gate, logic gate } is considered as a parent of { AND circuit, AND gate } because an AND gate is-a kind of logic gate


## WordNet is a Graph!

As shown in the Figure: Nouns in WordNet can be represented as a directed graph. Each vertex v is an integer that represents a synset, and each directed edge v→w represents the is-a relationship (v is-a w). A small subgraph of the WordNet digraph appears below.
![Screenshot 2023-08-09 030120](https://github.com/salmaelsy/WordNet-Semantics-Algorithm-project/assets/62834497/69892748-5c43-41ad-ab64-040ad0645aa7)



## $For \space More \space Details$ 
You can check the Documentation 
