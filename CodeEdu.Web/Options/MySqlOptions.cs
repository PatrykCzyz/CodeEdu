using System;
namespace CodeEdu.Web.Options;

public class MySqlOptions
{
	public class VersionOptions
	{
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }
    }

    public VersionOptions Version { get; set; }
}

