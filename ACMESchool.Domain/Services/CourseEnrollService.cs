using ACMESchool.Production.Domain;

namespace ACMESchool.Production.Services
{
    public class CourseEnrollService
    {
        private List<CourseEnroll> _courseEnrolls;

        public List<CourseEnroll> CourseEnrolls
        {
            get { return _courseEnrolls; }
            set { _courseEnrolls = value; }
        }

        public bool Exists( string courseName, string studentName )
        {
            return _courseEnrolls.Exists( match: ce => ce.CourseName == courseName && ce.StudentName == studentName );
        }

        /// <summary>
        /// Enrolls a student in a course.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="studentName">Name of the course.</param>
        /// <exception cref="Exception"></exception>
        public void Enroll( Course course, Student student, decimal paymentAmount )
        {
            if ( course == null )
            {
                throw new Exception( message: "Course not found." );
            }

            if ( student == null )
            {
                throw new Exception( message: "Student not found." );
            }

            if ( Exists( course.Name, student.FullName ) )
            {
                throw new Exception( message: "Student already enrolled in course." );
            }

            if ( !course.IsFree && paymentAmount < course.RegistrationFee )
            {
                throw new Exception( message: "Payment amount is less than registration fee." );
            }

            CourseEnroll courseEnroll = new CourseEnroll();
            courseEnroll.CourseName = course.Name;
            courseEnroll.StudentName = student.FullName;
            courseEnroll.PaymentDate = DateTime.Now;

            _courseEnrolls.Add( item: courseEnroll );
        }
    }
}