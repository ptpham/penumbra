
precision mediump float;

varying vec3 v_position, v_normal;

uniform vec3 start, end;
uniform float radius;

void main() {
  vec3 d0 = start - v_position;
  vec3 d1 = end - v_position;
  vec3 diff = end - start;

  float l0 = length(d0);
  float l1 = length(d1);
  float ld = length(diff);

  d0 /= l0;
  d1 /= l1;
  diff /= ld;

  float t = clamp(dot(v_position - start, diff), 0.0, ld);
  vec3 approach = t*diff + start - v_position;
  float la = length(approach);
  approach = approach / la;

  float theta0 = acos(clamp(dot(d0, approach), -1.0, 1.0));
  float theta1 = acos(clamp(dot(d1, approach), -1.0, 1.0));

  float radius2 = radius*radius;
  float hyp0 = sqrt(radius2 + l0*l0);
  float hyp1 = sqrt(radius2 + l1*l1);
  float hypa = sqrt(radius2 + la*la);

  float st0 = 1.0 - l0 / hyp0;
  float st1 = 1.0 - l1 / hyp1;
  float sta = 1.0 - la / hypa;

  float ndot = max(dot(v_normal, approach), 0.0);

  float factor = sta + 0.5*theta0*(sta + st0) + 0.5*theta1*(sta + st1);
  float value = 1.0 - ndot*factor;
  gl_FragColor = vec4(value, value, value, 1.0);
}

