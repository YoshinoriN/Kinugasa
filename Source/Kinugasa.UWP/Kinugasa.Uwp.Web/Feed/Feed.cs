using System;
using System.Collections.Generic;
using Windows.Web.Syndication;

namespace Kinugasa.Uwp.Web.Feed
{
    /// <summary>
    /// Content of RSS or Atom feed.
    /// Wrapp of <see cref="SyndicationItem"/> class.
    /// </summary>
    public class Feed
    {
        #region properties

        public string Id { get; }

        /// <summary>
        /// Base uri of feed.
        /// </summary>
        public Uri BaseUri { get; }

        /// <summary>
        /// Title of feed.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Summary of feed.
        /// </summary>
        public string Summary { get; }

        /// <summary>
        /// Categories of feed.
        /// </summary>
        public List<SyndicationCategory> Categories { get; }

        /// <summary>
        /// Authors
        /// </summary>
        public List<SyndicationPerson> Authors { get; }

        /// <summary>
        /// Copyright
        /// HACK : I have to confirm. This property is exists in SyndicationItem.
        /// </summary>
        public string Copyright { get; }

        /// <summary>
        /// Link into feed.
        /// </summary>
        public List<SyndicationLink> Links { get; }

        /// <summary>
        /// Publish of date.
        /// </summary>
        public DateTimeOffset PublishDate { get; }

        /// <summary>
        /// Last update of feed.
        /// </summary>
        public DateTimeOffset LastUpdatedTime { get; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="baseUri">Base uri of feed.</param>
        /// <param name="title">Title of feed.</param>
        /// <param name="summary">Summary of feed.</param>
        /// <param name="categories">Categories of feed.</param>
        /// <param name="authors">Authors</param>
        /// <param name="links">Link into feed.</param>
        /// <param name="publishdate">Publish of date.</param>
        /// <param name="lastupdateTime">Last update of feed.</param>
        public Feed(string id
                      ,Uri baseUri
                      ,string title
                      ,string summary
                      ,List<SyndicationCategory> categories
                      ,List<SyndicationPerson> authors
                      ,List<SyndicationLink> links
                      ,DateTimeOffset publishdate
                      ,DateTimeOffset lastupdateTime
                      )
        {
            this.Id = id;
            this.BaseUri = baseUri;
            this.Title = title;
            this.Summary = summary;
            this.Categories = categories;
            this.Authors = authors;
            this.Links = links;
            this.PublishDate = publishdate;
            this.LastUpdatedTime = lastupdateTime;
        }

    }
}
