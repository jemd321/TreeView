namespace TreeView
{
    /// <summary>
    /// Return object representing the result of a search of a <see cref="ParentFolder"/>.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResult"/> class.
        /// </summary>
        /// <param name="foundFolders">A collection containing any <see cref="Folder"/>s that matched the search criteria.</param>
        /// <param name="foundItems">A collection containing any <see cref="Item"/>s that matched the search criteria.</param>
        public SearchResult(List<Folder> foundFolders, List<Item> foundItems)
        {
            FoundFolders = foundFolders;
            FoundItems = foundItems;
        }

        /// <summary>
        /// Gets a value indicating whether the search found any results.
        /// </summary>
        public bool ResultFound => FoundFolders.Any() || FoundItems.Any();

        /// <summary>
        /// Gets a sequence of any <see cref="Folder"/>s that matched the search criteria.
        /// </summary>
        public List<Folder> FoundFolders { get; }

        /// <summary>
        /// Gets a sequence of any <see cref="Item"/>s that matched the search criteria.
        /// </summary>
        public List<Item> FoundItems { get; }
    }
}
