namespace ACMESchool.Production.Domain
{
    public class CourseEnroll
    {
        /// <summary>
        /// Name of the course.
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Name of the student.
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// Payment date.
        /// </summary>
        public DateTime PaymentDate { get; set; }
    }
}