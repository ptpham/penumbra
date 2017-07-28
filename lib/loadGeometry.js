
var createGeometry = require('gl-geometry');
var parseOBJ = require('parse-wavefront-obj');
var computeNormals = require('normals');

module.exports = function(gl, path) {
  return fetch(path).then(res => res.text()).then(parseOBJ)
    .then(mesh => Object.assign(mesh, { geometry: createGeometry(gl)
      .attr('position', mesh.positions)
      .attr('normal', computeNormals.vertexNormals(mesh.cells, mesh.positions))
      .faces(mesh.cells) }));
}

