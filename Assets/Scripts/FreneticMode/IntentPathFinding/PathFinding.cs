using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public Transform target;
    private Grid grid;
    private bool isGridReady = false;
    private bool isPlayerActive = false;

    void Start()
    {
        grid = FindObjectOfType<Grid>(); // Busca el componente Grid en la escena
        if (grid == null)
        {
            Debug.LogError("No se encontró ningún objeto con el script Grid en la escena.");
            return;
        }

        grid.OnGridInitialized += GridInitialized; // Suscribe el método GridInitialized al evento OnGridInitialized
    }

    void Update()
    {
        if (isPlayerActive && isGridReady)
        {
            FindPath(transform.position, target.position);
        }
    }

    void GridInitialized()
    {
        isGridReady = true; // Marca el grid como listo
        if (gameObject.activeSelf)
        {
            isPlayerActive = true; // Marca el jugador como activo si el GameObject está activo
        }
    }

    void OnEnable()
    {
        isPlayerActive = true; // Marca el jugador como activo cuando el GameObject se activa
    }

    void OnDisable()
    {
        isPlayerActive = false; // Marca el jugador como inactivo cuando el GameObject se desactiva
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos); // Obtiene el nodo de inicio del mundo
        Node targetNode = grid.NodeFromWorldPoint(targetPos); // Obtiene el nodo de destino del mundo

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (Node neighbor in grid.GetNeighbors(currentNode))
            {
                if (!neighbor.walkable || closedSet.Contains(neighbor))
                {
                    continue;
                }

                int newCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);
                if (newCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newCostToNeighbor;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }
    }

    void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        // Aquí puedes hacer lo que quieras con el camino, como mover un personaje a lo largo de él.
        // Por ejemplo, puedes guardar el camino en una variable y luego usarlo en otro script.
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}
