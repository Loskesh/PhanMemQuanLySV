using OOP1;
using System;
using System.Text.Json.Serialization;

namespace OOP1
{
    /// <summary>
    /// Lớp cơ sở quản lý trạng thái của sinh viên (áp dụng State Pattern)
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StudentStateConverter))]
    public abstract class StudentState
    {
        protected Student student;

        // Constructor mặc định cần thiết cho deserialization
        protected StudentState()
        {
            this.student = null; // Sẽ được gán sau khi deserialize
        }

        public StudentState(Student student)
        {
            this.student = student;
        }

        // Setter để gán student sau khi deserialize
        public void SetStudent(Student student)
        {
            this.student = student;
        }

        public abstract string GetStateName();
        public abstract string GetStateDescription();
        public abstract bool CanEnrollCourses();
        public abstract bool CanGraduate();
        public abstract bool CanTakeLeave();
        public abstract bool CanBeSuspended();
        public abstract bool CanBeReactivated();
    }

    [Serializable]
    public class ActiveState : StudentState
    {
        // Constructor mặc định cho deserialization
        public ActiveState() : base() { }

        // Constructor thông thường
        public ActiveState(Student student) : base(student) { }

        public override string GetStateName()
        {
            return "Active";
        }

        public override string GetStateDescription()
        {
            return "Sinh viên đang học tập bình thường";
        }

        public override bool CanEnrollCourses()
        {
            return true;
        }

        public override bool CanGraduate()
        {
            return true;
        }

        public override bool CanTakeLeave()
        {
            return true;
        }

        public override bool CanBeSuspended()
        {
            return true;
        }

        public override bool CanBeReactivated()
        {
            return false;
        }
    }

    [Serializable]
    public class OnLeaveState : StudentState
    {
        // Constructor mặc định cho deserialization
        public OnLeaveState() : base() { }

        // Constructor thông thường
        public OnLeaveState(Student student) : base(student) { }

        public override string GetStateName()
        {
            return "OnLeave";
        }

        public override string GetStateDescription()
        {
            return "Sinh viên đang tạm nghỉ học";
        }

        public override bool CanEnrollCourses()
        {
            return false;
        }

        public override bool CanGraduate()
        {
            return false;
        }

        public override bool CanTakeLeave()
        {
            return false;
        }

        public override bool CanBeSuspended()
        {
            return false;
        }

        public override bool CanBeReactivated()
        {
            return true;
        }
    }

    [Serializable]
    public class GraduatedState : StudentState
    {
        // Constructor mặc định cho deserialization
        public GraduatedState() : base() { }

        // Constructor thông thường
        public GraduatedState(Student student) : base(student) { }

        public override string GetStateName()
        {
            return "Graduated";
        }

        public override string GetStateDescription()
        {
            return "Sinh viên đã tốt nghiệp";
        }

        public override bool CanEnrollCourses()
        {
            return false;
        }

        public override bool CanGraduate()
        {
            return false;
        }

        public override bool CanTakeLeave()
        {
            return false;
        }

        public override bool CanBeSuspended()
        {
            return false;
        }

        public override bool CanBeReactivated()
        {
            return false;
        }
    }

    [Serializable]
    public class SuspendedState : StudentState
    {
        // Constructor mặc định cho deserialization
        public SuspendedState() : base() { }

        // Constructor thông thường
        public SuspendedState(Student student) : base(student) { }

        public override string GetStateName()
        {
            return "Suspended";
        }

        public override string GetStateDescription()
        {
            return "Sinh viên bị đình chỉ học tập";
        }

        public override bool CanEnrollCourses()
        {
            return false;
        }

        public override bool CanGraduate()
        {
            return false;
        }

        public override bool CanTakeLeave()
        {
            return false;
        }

        public override bool CanBeSuspended()
        {
            return false;
        }

        public override bool CanBeReactivated()
        {
            return true;
        }
    }
}