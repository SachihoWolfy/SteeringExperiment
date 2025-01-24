using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    // TODO: override Align's getTargetAngle to face the target instead of matching it's orientation
    public override float getTargetAngle()
    {
        float targetAngle = 0f;
        // To face something, we need to get the vector of our object, and then face that angle.
        // In this case we need the Y angle as a float.
        Vector3 direction = target.transform.position - character.transform.position;
        targetAngle = Quaternion.LookRotation(direction).eulerAngles.y;

        return targetAngle;
    }
}
