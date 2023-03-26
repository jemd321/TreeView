namespace TreeView
{
    /// <summary>
    /// Represents a node in the tree structure.
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="parent">The parent node of this node.</param>
        /// <param name="name">The name of this node.</param>
        public Node(ParentFolder parent, string name)
        {
            Parent = parent;
            Name = name;
        }

        /// <summary>
        /// Gets the name of this node.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the <see cref="ParentFolder"/> of this node.
        /// </summary>
        public ParentFolder Parent { get; set; }
    }
}
