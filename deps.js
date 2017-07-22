
Object.assign(window, require('gl-matrix'));
Object.assign(window, {
  _: require('lodash'),
  createShader: require('gl-shader'),
  createGeometry: require('gl-geometry'),
  computeNormals: require('normals'),
  parseOBJ: require('parse-wavefront-obj'),
  TurntableCamera: require('turntable-camera'),
  Icosphere: require('icosphere'),
  loadGeometry: require('./lib/loadGeometry'),
  Shaders: require('./lib/shaders'),
  Occluder: require('./lib/occluder'),
  Bound: require('./lib/bound'),
});

