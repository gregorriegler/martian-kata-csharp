using System;

namespace MartianTest{
    /**
     * This class is a placeholder for a real object that would be able to
     * control an electric stepper motor.
     */
    public class Stepper
    {
        /**
         * the number of steps to rotate a complete circle of 360 degrees
         */
        public const int STEPS = 2048;

        /**
         * speed of the motor in RPM
         */
        public const int MAX_SPEED = 15;
        private int speed;

        public Stepper() : this(8, 9, 10, 11)
        {
        }

        public Stepper(int pin1, int pin2, int pin3, int pin4)
        {
            speed = 10;
            // logic related to the pins is omitted in this exercise
        }

        /**
         * Set the speed of the motor in RPM. Maximum is defined above.
         */
        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        /**
         * move the indicated number of steps clockwise.
         * The size of a step is defined above.
         */
        public virtual void MoveClockwise(int steps)
        {
            // logic to activate the relevant pins is omitted in this exercise
        }
        public virtual void MoveAnticlockwise(int steps)
        {
            // logic to activate the relevant pins is omitted in this exercise
        }

        /**
         * Whether the motor is currently running.
         * Motors that are moving should not be given new instructions.
         */
        public bool IsRunning()
        {
            // logic to read the pins and determine this omitted in this exercise
            return false;
        }
    }
}
