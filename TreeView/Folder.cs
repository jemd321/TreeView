namespace TreeView
{
    /// <summary>
    /// Represents a node in the structure that can contain other nodes.
    /// </summary>
    public class Folder : ParentFolder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Folder"/> class.
        /// </summary>
        /// <param name="parent">The parent node of this node.</param>
        /// <param name="name">The name of this node.</param>
        public Folder(ParentFolder parent, string name)
            : base(parent, name)
        {
        }

        /// <summary>
        /// Deletes this <see cref="Folder"/>.
        /// </summary>
        public void Delete() => Parent.DeleteFolder(this);

        /// <summary>
        /// Moves this <see cref="Folder"/> to another <see cref="ParentFolder"/>.
        /// </summary>
        /// <param name="destinationFolder">The <see cref="ParentFolder"/> to move this folder to.</param>
        public void Move(Folder destinationFolder) => Parent.MoveChildFolder(this, destinationFolder);
    }
}
