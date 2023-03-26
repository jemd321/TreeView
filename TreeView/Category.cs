namespace TreeView
{
    /// <summary>
    /// Represents a hierarchical structure with only one root node.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="rootFolderName">The name of the root folder.</param>
        public Category(string rootFolderName)
        {
            RootFolder = RootFolder.CreateRootFolderForCategory(this, rootFolderName);
        }

        /// <summary>
        /// Gets the root node of the structure.
        /// </summary>
        public RootFolder RootFolder { get; }
    }
}
