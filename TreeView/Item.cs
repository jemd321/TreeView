namespace TreeView
{
    /// <summary>
    /// Represents a node of a category tree structure that cannot contain children.
    /// </summary>
    public class Item : Node
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="parent">The parent node of this node.</param>
        /// <param name="name">The name of this node.</param>
        public Item(ParentFolder parent, string name)
            : base(parent, name)
        {
        }

        /// <summary>
        /// Deletes this item.
        /// </summary>
        public void Delete() => Parent.DeleteItem(this);

        /// <summary>
        /// Moves this item to another folder.
        /// </summary>
        /// <param name="destinationFolder">The <see cref="ParentFolder"/> that this item will move to.</param>
        public void Move(ParentFolder destinationFolder) => Parent.MoveChildItem(this, destinationFolder);
    }
}
