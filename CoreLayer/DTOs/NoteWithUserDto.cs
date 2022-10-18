using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.DTOs
{
    public class NoteWithUserDto:NoteDto
    {
        public UserDto  User  { get; set; }
       // public List<UserDto> Users { get; set; }
    }
}
