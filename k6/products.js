import http from "k6/http";
import { check, sleep } from "k6";

export const options = {
  // A number specifying the number of VUs to run concurrently.
  vus: 10,
  // A string specifying the total duration of the test run.
  // duration: '30s',

  thresholds: {
    http_req_failed: [{ threshold: 'rate<0.01', abortOnFail: true }], // http errors should be less than 1%, otherwise abort the test
    http_req_duration: ['p(99)<100'], // 99% of requests should be below 1s
  },

  // define scenarios
  scenarios: {
    // arbitrary name of scenario
    average_load: {
      executor: 'ramping-vus',
      stages: [
        // ramp up to average load of 20 virtual users
        { duration: '5s', target: 20 },
        // maintain load
        { duration: '30s', target: 20 },
        // ramp down to zero
        { duration: '5s', target: 0 },
      ],
    },
  },
};

// The function that defines VU logic.
//
// See https://grafana.com/docs/k6/latest/examples/get-started-with-k6/ to learn more
// about authoring k6 scripts.
//
export default function () {
  // define URL and request body
  const url = "http://localhost:5265/api/Products";

  // send a post request and save response as a variable
  const res = http.get(url);

  // check that response is 200
  check(res, {
    "response code was 200": (res) => res.status == 200,
  });

  // sleep(1);
}
