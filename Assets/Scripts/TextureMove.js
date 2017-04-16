#pragma strict

var xOffset = 0.0;
var yOffset = 0.0;

function Start () {
	var uvs: Vector2[] = new Vector2[(GetComponent(MeshFilter) as
	MeshFilter).mesh.vertices.Length];

	uvs = (GetComponent(MeshFilter) as MeshFilter).mesh.uv;

	for (var i = 0; i &lt; uvs.Length; i++) uvs[i] = Vector2 (uvs[i].x + xOffset, uvs[i].y + yOffset);
}

function Update () {
	(GetComponent(MeshFilter) as MeshFilter).mesh.uv = uvs;
}
