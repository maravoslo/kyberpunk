using UnityEngine;
public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    private float maxSpeed = 8f;
    public Rigidbody2D rb2d;
    public GameObject PanelFinish;
    public GameObject PanelFailed;
    public GameObject TextTime;
    private Vector3 mousePosition;
    private Vector3 currentPosition;
    private Vector2 var;
    private float force;
    private float maxforce = 400f;
    [SerializeField]
    private LineRenderer lr;
    [SerializeField]
    private TimeController ceva;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        rb2d.velocity += direction;

        rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb2d.velocity.y, -maxSpeed, maxSpeed));

        if (Input.GetMouseButtonUp(1))
        {
            DashAbility();
            EndLIne();
        }


        if (Input.GetMouseButton(1))
        {
            if (force < maxforce)
            {
                force++;
            }
            currentPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Vector3 direction1 = (new Vector3(currentPosition.x - transform.position.x, currentPosition.y - transform.position.y, 0)).normalized;
            var v = Vector3.Lerp(transform.position, transform.position + direction1 * 3, force / 600f);
            //Debug.Log(currentPosition);
            RenderLine(transform.position, v);
        }

    }
    public void DashAbility()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - transform.position;
        var = new Vector2(mousePosition.x, mousePosition.y);
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(var * force, ForceMode2D.Force);

        force = 0;
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lr.positionCount = 2;

        // Debug.Log(points[0] +  " " + points[1]);

        lr.SetPosition(0, startPoint);
        lr.SetPosition(1, endPoint);
    }

    public void EndLIne()
    {
        lr.positionCount = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "WallTag") || (col.tag == "ObstacleTag"))
        {
            gameObject.SetActive(false);
            bool isActive = PanelFailed.activeSelf;
            PanelFailed.SetActive(!isActive);
            TextTime.gameObject.SetActive(false);
            ceva.EndTimer();
        }

        if (col.tag == "PortalTag")
        {
            gameObject.SetActive(false);
            bool isActive = PanelFinish.activeSelf;
            PanelFinish.SetActive(!isActive);
            TextTime.gameObject.SetActive(false);
            ceva.EndTimer();
        }
    }
}
