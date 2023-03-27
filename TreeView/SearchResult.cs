namespace TreeView
{
    /// <summary>
    /// Return object representing the result of a search of a <see cref="ParentFolder"/>.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Gets a value indicating whether the search found any results.
        /// </summary>
        public bool ResultFound => FoundFolders.Any() || FoundItems.Any();

        /// <summary>
        /// Gets a sequence of any <see cref="Folder"/>s that matched the search criteria.
        /// </summary>
        public List<Folder> FoundFolders { get; } = new();

        /// <summary>
        /// Gets a sequence of any <see cref="Item"/>s that matched the search criteria.
        /// </summary>
        public List<Item> FoundItems { get; } = new();
    }
}
