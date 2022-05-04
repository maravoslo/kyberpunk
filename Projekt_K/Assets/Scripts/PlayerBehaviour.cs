using UnityEngine;
/*
stelute in functie de timpul pe care l scoti
inamici care trag in tine
steluta default daca termini lvl indiferent de timp, ca sa poti trece mai departe
tutorial (daca nu l faci, nu se deschide butonu de level)
loading screen
podeaua
secret room in level 4 in care daca intri, sa primesti o a patra steluta
 */
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
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        rb2d.velocity += direction;

        rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb2d.velocity.y, -maxSpeed, maxSpeed));

        if (Input.GetMouseButtonUp(0))
        {
            DashAbility();
            EndLIne();
        }


        if (Input.GetMouseButton(0))
        {
            if (force < maxforce)
            {
                force++;
            }
            currentPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            Vector3 direction1 = (new Vector3(currentPosition.x - transform.position.x, currentPosition.y - transform.position.y, 0)).normalized;
            var v = Vector3.Lerp(transform.position, transform.position + direction1 * 3, force / 600f);
            //Debug.Log(currentPosition);
            RenderLine(transform.position, v);
        }

    }
    public void DashAbility()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - transform.position;
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
        }

        if (col.tag == "PortalTag")
        {
            gameObject.SetActive(false);
            bool isActive = PanelFinish.activeSelf;
            PanelFinish.SetActive(!isActive);
            TextTime.gameObject.SetActive(false);
        }
    }
}
