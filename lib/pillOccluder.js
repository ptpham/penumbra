
var _ = require('lodash');
var { vec3 } = require('gl-matrix');

class PillOccluder {
  constructor(start, end, radius) {
    this._space = vec3.create();
    this.radius = radius;
    this.start = start;
    this.end = end;
  }

  clone() { return new PillOccluder(this.start, this.end, this.radius); }
  copy(other) {
    vec3.copy(this.start, other.start);
    vec3.copy(this.end, other.end);
    this.radius = other.radius;
  }

  transformMat4(mat) {
    var { start, end, radius, _space } = this;

    vec3.sub(_space, end, start);
    vec3.normalize(_space, _space);
    vec3.scale(_space, _space, radius);
    vec3.add(_space, _space, end);

    vec3.transformMat4(end, end, mat);
    vec3.transformMat4(start, start, mat);
    vec3.transformMat4(_space, _space, mat);
    this.radius = vec3.distance(_space, end);
  }

  static fromAABB(box) {
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
    return new PillOccluder(start, end, radius);
  }
}

module.exports = PillOccluder;

