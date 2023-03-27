using System.Text.RegularExpressions;

namespace TreeView
{
    /// <summary>
    /// Represents a folder node in the tree structure which can contain child nodes.
    /// </summary>
    public abstract class ParentFolder : Node
    {
        private readonly List<Folder> _childFolders = new();
        private readonly List<Item> _childItems = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ParentFolder"/> class.
        /// </summary>
        /// <param name="parent">The parent node of this node.</param>
        /// <param name="name">The name of this node.</param>
        public ParentFolder(ParentFolder parent, string name)
            : base(parent, name)
        {
        }

        /// <summary>
        /// Gets a sequence of the child <see cref="Folder"/>s of this folder.
        /// </summary>
        public IEnumerable<Folder> ChildFolders => _childFolders;

        /// <summary>
        /// Gets a sequence of the child <see cref="Item"/>s of this folder.
        /// </summary>
        public IEnumerable<Item> ChildItems => _childItems;

        /// <summary>
        /// Adds a <see cref="Folder"/> as a child of this node.
        /// </summary>
        /// <param name="folder">The child folder to be added.</param>
        public void AddFolder(Folder folder) => _childFolders.Add(folder);

        /// <summary>
        /// Adds a sequence of <see cref="Folder"/>s as children of this node.
        /// </summary>
        /// <param name="folders">The seqence of child folders to be added.</param>
        public void AddFolders(IEnumerable<Folder> folders)
        {
            foreach (Folder folder in folders)
            {
                _childFolders.Add(folder);
            }
        }

        /// <summary>
        /// Adds an <see cref="Item"/> as a child of this node.
        /// </summary>
        /// <param name="item">The child item to be added.</param>
        public void AddItem(Item item)
        {
            item.Parent = this;
            _childItems.Add(item);
        }

        /// <summary>
        /// Adds a sequence of <see cref="Item"/>s as children of this node.
        /// </summary>
        /// <param name="items">The seqence of child items to be added.</param>
        public void AddItems(IEnumerable<Item> items)
        {
            foreach (Item item in items)
            {
                _childItems.Add(item);
            }
        }

        /// <summary>
        /// Deletes a child <see cref="Folder"/> from this node.
        /// </summary>
        /// <param name="folder">The child <see cref="Folder"/> to be deleted.</param>
        public void DeleteFolder(Folder folder) => _childFolders.Remove(folder);

        /// <summary>
        /// Deletes a sequence of child <see cref="Folder"/>s from this node.
        /// </summary>
        /// <param name="folders">The sequence of child <see cref="Folder"/>s to be deleted.</param>
        public void DeleteFolders(IEnumerable<Folder> folders)
        {
            foreach (Folder folder in folders)
            {
                DeleteFolder(folder);
            }
        }

        /// <summary>
        /// Deletes a child <see cref="Item"/> from this node.
        /// </summary>
        /// <param name="item">The child <see cref="Item"/> to be deleted.</param>
        public void DeleteItem(Item item) => _childItems.Remove(item);

        /// <summary>
        /// Deletes a sequence of child <see cref="Item"/>s from this node.
        /// </summary>
        /// <param name="items">The sequence of child <see cref="Item"/>s to be deleted.</param>
        public void DeleteItems(IEnumerable<Item> items)
        {
            foreach (Item item in items)
            {
                DeleteItem(item);
            }
        }

        /// <summary>
        /// Moves a child <see cref="Folder"/> to a new <see cref="ParentFolder"/>.
        /// </summary>
        /// <param name="childFolder">The child <see cref="Folder"/> to be moved.</param>
        /// <param name="destinationFolder">The <see cref="ParentFolder"/> to move the child to.</param>
        public void MoveChildFolder(Folder childFolder, ParentFolder destinationFolder)
        {
            if (_childFolders.Remove(childFolder))
            {
                destinationFolder.AddFolder(childFolder);
            }
        }

        /// <summary>
        /// Moves a child <see cref="Item"/> to a new <see cref="ParentFolder"/>.
        /// </summary>
        /// <param name="childItem">The child <see cref="Item"/> to be moved.</param>
        /// <param name="destinationFolder">The <see cref="ParentFolder"/> to move the child to.</param>
        public void MoveChildItem(Item childItem, ParentFolder destinationFolder)
        {
            if (_childItems.Remove(childItem))
            {
                destinationFolder.AddItem(childItem);
            }
        }

        /// <summary>
        /// Searches this folder and all subfolders for any node with a matching name.
        /// </summary>
        /// <param name="searchRegex">A <see cref="Regex"/> instance that will match the desired name.</param>
        /// <returns>A <see cref="SearchResult"/> instance that encompasses the result of the search and contains the data found.</returns>
        public SearchResult Search(Regex searchRegex)
        {
            List<Item> foundItems = _childItems.FindAll(item => searchRegex.IsMatch(item.Name));
            List<Folder> foundFolders = _childFolders.FindAll(folder => searchRegex.IsMatch(folder.Name));
            var searchResults = new SearchResult(foundFolders, foundItems);

            foreach (Folder folder in ChildFolders)
            {
                SearchChildren(searchRegex, searchResults);
            }

            return searchResults;
        }

        private void SearchChildren(Regex searchRegex, SearchResult searchResults)
        {
            searchResults.FoundItems.AddRange(_childItems.FindAll(item => searchRegex.IsMatch(item.Name)));
            searchResults.FoundFolders.AddRange(_childFolders.FindAll(folder => searchRegex.IsMatch(folder.Name)));
            foreach (Folder folder in ChildFolders)
            {
                SearchChildren(searchRegex, searchResults);
            }
        }
    }
}
