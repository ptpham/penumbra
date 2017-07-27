
precision mediump float;

varying vec3 v_position, v_normal;

uniform vec3 start, end;
uniform float radius;

void main() {
  vec3 normal = normalize(v_normal);
  vec3 d0 = start - v_position;
  vec3 d1 = end - v_position;
  vec3 dir = end - start;

  float l0 = length(d0);
  float l1 = length(d1);
  float ld = length(dir);

  d0 /= l0;
  d1 /= l1;
  dir /= ld;

  float t = clamp(dot(v_position - start, dir), 0.0, ld);
  vec3 approach = t*dir + start - v_position;
  float la = length(approach);
  approach = approach / la;

  float gammaa = asin(min(radius/la, 1.0));
  float gamma0 = asin(min(radius/l0, 1.0));
  float gamma1 = asin(min(radius/l1, 1.0));

  float theta0_raw = acos(clamp(dot(d0, approach), -1.0, 1.0));
  float theta1_raw = acos(clamp(dot(d1, approach), -1.0, 1.0));

  float theta0 = max(theta0_raw - 0.5*gammaa, 0.0);
  float theta1 = max(theta1_raw - 0.5*gammaa, 0.0);

  float ndot0 = dot(normal, d0);
  float ndot1 = dot(normal, d1);
  float ndota = dot(normal, approach);

  float st0 = 0.5*(ndot0 + 1.0) * (1.0 - cos(gamma0));
  float st1 = 0.5*(ndot1 + 1.0) * (1.0 - cos(gamma1));
  float sta = 0.5*(ndota + 1.0) * (1.0 - cos(gammaa));

  float factor = sta + 0.5*theta0*(sta + st0) + 0.5*theta1*(sta + st1);
  float value = 1.0 - factor;

  gl_FragColor = vec4(value, value, value, 1.0);
}

