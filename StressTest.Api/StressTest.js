import http from 'k6/http';
import { check } from 'k6';

export let options = {
    stages: [
        { duration: '30s', target: 5 },  // ramp up to 5 users
        { duration: '1m', target: 10 },   // increase to 10 users
        { duration: '30s', target: 20 },  // peak at 20 users
        { duration: '20s', target: 0 }    // cool down to 0 users
    ]
};

export default function () {
    let headers = {
        'accept': 'application/json'
    };

    let res = http.get('https://localhost:7132/ListUsers', { headers: headers });

    // Add checks for expected response status and conditions
    check(res, {
        'is status 200': (r) => r.status === 200,
        'response body is non-empty': (r) => r.body.length > 0,
    });
}
