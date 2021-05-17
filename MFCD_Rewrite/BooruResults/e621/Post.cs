using System;
using System.Collections.Generic;

namespace MFCD.BooruResults.e621{ 

    public class Post
    {
        public int Id                   { get; set; }
        public DateTime CreatedAt       { get; set; }
        public DateTime UpdatedAt       { get; set; }
        public File File                { get; set; }
        public Preview Preview          { get; set; }
        public Sample Sample            { get; set; }
        public Score Score              { get; set; }
        public Tags Tags                { get; set; }
        public List<object> LockedTags  { get; set; }
        public int ChangeSeq            { get; set; }
        public Flags Flags              { get; set; }
        public string Rating            { get; set; }
        public int FavCount             { get; set; }
        public List<string> Sources     { get; set; }
        public List<object> Pools           { get; } = new();
        public Relationships Relationships { get; set; }
        public int? ApproverId { get; set; }
        public int UploaderId { get; set; }
        public string Description { get; set; }
        public int CommentCount { get; set; }
        public bool IsFavorited { get; set; }
        public bool HasNotes { get; set; }
        public double? Duration { get; set; }
    }

}