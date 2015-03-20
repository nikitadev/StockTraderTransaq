using System.Xml.Serialization;

namespace TransaqModelComponent.Models.Commands
{
    /// <summary>
    /// change_pass
    /// </summary>
    public class ChangePassword : Command
    {
        [XmlAttribute("oldpass")]
        public string Old { get; set; }

        [XmlAttribute("newpass")]
        public string New { get; set; }

        public ChangePassword() 
            : base(CommandNames.ChangePass)
        { }
    }
}
