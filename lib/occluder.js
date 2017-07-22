
var _ = require('lodash');
var { vec3 } = require('gl-matrix');

function aabbToPill(box) {
  var dim = _.maxBy(_.times(3), i => box.max[i] - box.min[i]);
  var start = vec3.create();
  var end = vec3.create();
  var radius = 0;

  for (var i = 0; i < 3; i++) {
    if (i != dim) {
      radius += (box.max[i] - box.min[i])/4;
    } else {
      var center = (box.max[i] + box.min[i])/2;
      start[i] = center;
      end[i] = center;
    }
  }

  end[dim] = box.max[dim] - radius;
  start[dim] = box.min[dim] + radius;
  return { start, end, radius };
}

module.exports = { aabbToPill };

