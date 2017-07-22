
var { vec3 } = require('gl-matrix');

function aabb(points) {
  var min = vec3.create();
  var max = vec3.create();

  for (var point of points) {
    vec3.min(min, min, point);
    vec3.max(max, max, point);
  }

  return { min, max };
}

module.exports = { aabb };

