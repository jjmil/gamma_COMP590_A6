
using UnityEngine;

public class QueenGrab : MonoBehaviour
{
    public string rookName = "Chess Rook (1)";
    public string kingName = "Chess King (1)";
    public string pawnName = "Chess Pawn Black";

    public float allowedDistance = 0.15f;

    private bool IsNextTo(GameObject piece, GameObject target)
    {
        if (piece == null || target == null)
            return false;

        Vector3 a = piece.transform.position;
        Vector3 b = target.transform.position;

        // Ignore height differences
        a.y = 0;
        b.y = 0;

        return Vector3.Distance(a, b) <= allowedDistance;
    }

    public bool CanPlaceQueen()
    {
        GameObject rook = GameObject.Find(rookName);
        GameObject king = GameObject.Find(kingName);
        GameObject pawn = GameObject.Find(pawnName);

        if (rook == null || king == null || pawn == null)
        {
            Debug.LogError("Could not find all required chess pieces!");
            return false;
        }

        bool nextToRook = IsNextTo(gameObject, rook);
        bool nextToKing = IsNextTo(gameObject, king);
        bool nextToPawn = IsNextTo(gameObject, pawn);

        return nextToRook && nextToKing && nextToPawn;
    }
}
