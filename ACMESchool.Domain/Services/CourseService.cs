using ACMESchool.Production.Domain;

namespace ACMESchool.Production.Services
{
    public class CourseService
    {
        private List<Course> _courses;

        /// <summary>
        /// List of courses.
        /// </summary>
        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CourseService()
        {
            _courses = new List<Course>();
        }

        /// <summary>
        /// Register a new course.
        /// </summary>
        public void Register( Course course )
        {
            if ( _courses.Exists( match: course => course.Name == course.Name ) )
            {
                throw new Exception( message: "Course already exists." );
            }
            else
            {
                _courses.Add( item: course );
            }
        }

        /// <summary>
        /// Delete a course.
        /// </summary>
        public void Delete( string courseName )
        {
            var course = _courses.Find( match: course => course.Name == courseName );

            if ( course != null )
            {
                _courses.Remove( item: course );
            }
            else
            {
                throw new Exception( message: "Course not found." );
            }
        }

        /// <summary>
        /// Check if a course exists.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <returns></returns>
        public bool Exists( string courseName )
        {
            return _courses.Exists( match: course => course.Name == courseName );
        }

        /// <summary>
        /// Get a list of courses within a specified date range.
        /// </summary>
        /// <param name="startDate">Start date of the course.</param>
        /// <param name="endDate">End date of the course.</param>
        public List<Course> GetList( DateTime startDate, DateTime endDate )
        {
            // Get list logic here
            if ( startDate > endDate )
            {
                throw new Exception( message: "Start date cannot be greater than end date." );
            }

            if ( _courses == null || _courses.Count == 0 )
            {
                return new List<Course>();
            }

            return _courses
                .Where( predicate: c => c.StartDate >= startDate && c.EndDate <= endDate )
                .ToList() ?? new List<Course>();
        }
    }
}