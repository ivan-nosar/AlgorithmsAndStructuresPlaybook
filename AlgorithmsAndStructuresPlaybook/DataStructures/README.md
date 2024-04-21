# Data structures

This section provides implementation guides for data structures commonly discussed in technical
interviews.

## Constraints & assumptions

For the sake of convenience, we will establish constraints and assumptions that highlight the
essential aspects of implementation without sacrificing generality.

* **Integer values**: Every data structure is intended to hold and manipulate values of one
  specific type (integers, strings, structs, etc.). `C#` provides us with an exhaustive way to
  implement generic classes that can handle values of any type in a generalized manner. However,
  generic types introduce additional complexity into certain aspects of implementations (such as
  comparing two different elements). That's a point we can sacrifice in favor of brevity and
  convenience. So we have come to the assumption that every data structure capable of storing
  values will work with integer (`int`, `Int32`) numbers only
  * _Integer keys, string values_: For data structures that usually store `key-value` pairs, we've
    decided to treat the key as an item of integer (`int`, `Int32`) type, while the value type will
    be of type `string`.
* **Naive implementation**: This is a demo project with a major focus on the academic presentation
  of the material. It's not intended to work as fast and optimized as possible under heavy load or
  on various sets of hardware. That's why the code implemented in respective `C#` classes doesn't
  contain some important optimizations that are vital for library implementations of the same data
  structures. Thus, we gain more clarity and brevity for our code. A striking example of such a
  trade-off is a binary tree implementation: We consider a tree node as a separate `class` that
  holds links to the parent and children nodes along with the data item itself. Real-world
  implementations usually can't afford such overhead to store 3 additional pointers per each stored
  value; In turn, they usually store tree data in a flat array that keeps parent-children
  relationships by element indices (`0` element is a root, `1-2` elements - are children of the
  root, `3-4` - are children of `1`, and so on).
