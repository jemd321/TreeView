namespace TreeView
{
    /// <summary>
    /// Return object representing the result of a search of a <see cref="ParentFolder"/>.
    /// </summary>
    public class SearchResult
    {
        private readonly List<Folder> _foundFolders;
        private readonly List<Item> _foundItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResult"/> class.
        /// </summary>
        /// <param name="foundFolders">A collection containing any <see cref="Folder"/>s that matched the search criteria.</param>
        /// <param name="foundItems">A collection containing any <see cref="Item"/>s that matched the search criteria.</param>
        public SearchResult(List<Folder> foundFolders, List<Item> foundItems)
        {
            _foundFolders = foundFolders;
            _foundItems = foundItems;
        }

        /// <summary>
        /// Gets a value indicating whether the search found any results.
        /// </summary>
        public bool ResultFound => FoundFolders.Any() || FoundItems.Any();

        /// <summary>
        /// Gets a sequence of any <see cref="Folder"/>s that matched the search criteria.
        /// </summary>
        public IEnumerable<Folder> FoundFolders => _foundFolders;

        /// <summary>
        /// Gets a sequence of any <see cref="Item"/>s that matched the search criteria.
        /// </summary>
        public IEnumerable<Item> FoundItems => _foundItems;
    }
}
