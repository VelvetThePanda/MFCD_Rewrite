using System;

namespace MFCD.BooruResults.e621
{
    public class E621Result
    {
        public Post[] Posts { get; set; }
    }

    public class Post
    {
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public File File { get; set; }
        public Preview Preview { get; set; }
        public Sample Sample { get; set; }
        public Score Score { get; set; }
        public Tags Tags { get; set; }
        public object[] LockedTags { get; set; }
        public long ChangeSeq { get; set; }
        public Flags Flags { get; set; }
        public Rating Rating { get; set; }
        public long FavCount { get; set; }
        public Uri[] Sources { get; set; }
        public long[] Pools { get; set; }
        public Relationships Relationships { get; set; }
        public long? ApproverId { get; set; }
        public long UploaderId { get; set; }
        public string Description { get; set; }
        public long CommentCount { get; set; }
        public bool IsFavorited { get; set; }
        public bool HasNotes { get; set; }
        public double? Duration { get; set; }
    }

    public class File
    {
        public long Width { get; set; }
        public long Height { get; set; }
        public Ext Ext { get; set; }
        public long Size { get; set; }
        public string Md5 { get; set; }
        public Uri Url { get; set; }
    }

    public class Flags
    {
        public bool Pending { get; set; }
        public bool Flagged { get; set; }
        public bool NoteLocked { get; set; }
        public bool StatusLocked { get; set; }
        public bool RatingLocked { get; set; }
        public bool Deleted { get; set; }
    }

    public class Preview
    {
        public long Width { get; set; }
        public long Height { get; set; }
        public Uri Url { get; set; }
    }

    public class Relationships
    {
        public long? ParentId { get; set; }
        public bool HasChildren { get; set; }
        public bool HasActiveChildren { get; set; }
        public long[] Children { get; set; }
    }

    public class Sample
    {
        public bool Has { get; set; }
        public long Height { get; set; }
        public long Width { get; set; }
        public Uri Url { get; set; }
        public Alternates Alternates { get; set; }
    }

    public class Alternates
    {
        public The0_P The480P { get; set; }
        public The0_P The720P { get; set; }
        public Original Original { get; set; }
    }

    public class Original
    {
        public string Type { get; set; }
        public long Height { get; set; }
        public long Width { get; set; }
        public Uri[] Urls { get; set; }
    }

    public class The0_P
    {
        public string Type { get; set; }
        public long Height { get; set; }
        public long Width { get; set; }
        public Uri[] Urls { get; set; }
    }

    public class Score
    {
        public long Up { get; set; }
        public long Down { get; set; }
        public long Total { get; set; }
    }

    public class Tags
    {
        public string[] General { get; set; }
        public string[] Species { get; set; }
        public string[] Character { get; set; }
        public string[] Copyright { get; set; }
        public string[] Artist { get; set; }
        public string[] Invalid { get; set; }
        public string[] Lore { get; set; }
        public string[] Meta { get; set; }
    }

    public enum Ext { Jpg, Png, Webm, Gif };

    public enum Rating { E, Q, S };
}
