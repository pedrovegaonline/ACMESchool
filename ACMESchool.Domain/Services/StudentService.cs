using ACMESchool.Production.Domain;

namespace ACMESchool.Production.Services
{
    public class StudentService
    {
        private List<Student> _students;

        /// <summary>
        /// List of students.
        /// </summary>
        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StudentService()
        {
            _students = new List<Student>();
        }

        /// <summary>
        /// Register a new student.
        /// </summary>
        public void Register( Student student )
        {
            if ( _students.Exists( match: student => student.FullName == student.FullName ) )
            {
                throw new Exception( message: "Student already exists." );
            }
            else
            {
                _students.Add( item: student );
            }
        }

        /// <summary>
        /// Delete a student.
        /// </summary>
        public void Delete( string fullName )
        {
            var student = _students.Find( match: student => student.FullName == fullName );

            if ( student != null )
            {
                _students.Remove( item: student );
            }
            else
            {
                throw new Exception( message: "Student not found." );
            }
        }
    }
}