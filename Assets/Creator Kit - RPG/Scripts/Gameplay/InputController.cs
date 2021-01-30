using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;

namespace RPGM.UI
{
    /// <summary>
    /// Sends user input to the correct control systems.
    /// </summary>
    public class InputController : MonoBehaviour
    {
        public float stepSize = 0.1f;
        GameModel model = Schedule.GetModel<GameModel>();
        public GameObject Ball;
        public int rotationSide = 0;

        public enum State
        {
            CharacterControl,
            DialogControl,
            Pause
        }

        State state;

        public void ChangeState(State state) => this.state = state;

        void Update()
        {
            switch (state)
            {
                case State.CharacterControl:
                    CharacterControl();
                    break;
                case State.DialogControl:
                    DialogControl();
                    break;
            }
        }

        private void FixedUpdate(){
            if (Input.GetKey(KeyCode.LeftArrow))
                rotationSide = 1;
            else if (Input.GetKey(KeyCode.RightArrow))
                rotationSide = 3;
            else if (Input.GetKey(KeyCode.DownArrow))
                rotationSide = 0;
            else if (Input.GetKey(KeyCode.UpArrow))
                rotationSide = 2;
        }

        void DialogControl()
        {
            model.player.nextMoveCommand = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                model.dialog.FocusButton(-1);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                model.dialog.FocusButton(+1);
            if (Input.GetKeyDown(KeyCode.Space))
                model.dialog.SelectActiveButton();
        }

        void CharacterControl()
        {
            if (Input.GetKey(KeyCode.UpArrow))
                model.player.nextMoveCommand = Vector3.up * stepSize;
            else if (Input.GetKey(KeyCode.DownArrow))
                model.player.nextMoveCommand = Vector3.down * stepSize;
            else if (Input.GetKey(KeyCode.LeftArrow))
                model.player.nextMoveCommand = Vector3.left * stepSize;
            else if (Input.GetKey(KeyCode.RightArrow))
                model.player.nextMoveCommand = Vector3.right * stepSize;
            else if (Input.GetKeyDown(KeyCode.C)){
                GameObject BallInstance = Instantiate(Ball, transform.position, transform.rotation);
                Rigidbody2D BallRigidbody = BallInstance.GetComponent<Rigidbody2D>();
                if (rotationSide == 1)
                    BallRigidbody.AddForce(new Vector2(-80, 0), ForceMode2D.Impulse);
                else if (rotationSide == 0)
                    BallRigidbody.AddForce(new Vector2(0, -80), ForceMode2D.Impulse); 
                else if (rotationSide == 2)
                    BallRigidbody.AddForce(new Vector2(0, 80), ForceMode2D.Impulse); 
                else if (rotationSide == 3)
                    BallRigidbody.AddForce(new Vector2(80, 0), ForceMode2D.Impulse); 
                

                Destroy(BallInstance, 0.5f);
            } 

            else
                model.player.nextMoveCommand = Vector3.zero;
        }
    }
}