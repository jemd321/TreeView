namespace TreeView
{
    /// <summary>
    /// A folder representing the root of the tree, of which there can only be one.
    /// </summary>
    public class RootFolder : ParentFolder
    {
        private RootFolder(string name)
            : base(null, name)
        {
            // null passed as argument for Parent, as the root cannot have a parent.
        }

        /// <summary>
        /// Creates a single instance of the root folder for a category. Prevents creation of multiple root objects.
        /// </summary>
        /// <param name="category">The category to create the root folder for.</param>
        /// <param name="rootFolderName">The name to give the root folder.</param>
        /// <returns>A <see cref="RootFolder"/> for the category.</returns>
        public static RootFolder CreateRootFolderForCategory(Category category, string rootFolderName)
        {
            if (category.RootFolder is null)
            {
                return new RootFolder(rootFolderName);
            }
            else
            {
                throw new InvalidOperationException("Each category can only contain one root node");
            }
        }
    }
}
