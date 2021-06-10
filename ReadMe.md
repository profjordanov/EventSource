# Event Sourcing as a Service
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](http://makeapullrequest.com)
[![Build Status](https://travis-ci.com/profjordanov/EventSource.svg?branch=main)](https://travis-ci.com/profjordanov/EventSource)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/336d1f8c57b34420b454bbcc836d4088)](https://www.codacy.com/gh/profjordanov/EventSource/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=profjordanov/EventSource&amp;utm_campaign=Badge_Grade)
[![GitHub issues](https://img.shields.io/github/issues/profjordanov/EventSource)](https://github.com/profjordanov/EventSource/issues)
[![GitHub license](https://img.shields.io/github/license/profjordanov/EventSource)](https://github.com/profjordanov/EventSource/blob/main/LICENSE)

This project aims to prototype event store via web api.

## Brief introduction of the event sourcing pattern
It's about ensuring that all changes made to the application state during the entire lifetime of the application
are stored as a sequence of events.

![alt text](https://raw.githubusercontent.com/profjordanov/EventSource/master/docs/Capture2.JPG)

![alt text](https://raw.githubusercontent.com/profjordanov/EventSource/master/docs/Capture3.JPG)

![alt text](https://raw.githubusercontent.com/profjordanov/EventSource/master/docs/Capture4.JPG)

![alt text](https://raw.githubusercontent.com/profjordanov/EventSource/master/docs/Capture5.JPG)

### Event Store on PostgreSQL with Marten
The Marten library provides .NET developers with the ability to easily use PostgreSQL database engine with JSONB support to expose an ACID-compliant event store.

## Prerequisites
If you have Docker installed you can just double-click run-app.sh .

## Example

Start the app and execute a POST request to the /api/UpcomingEvents/receive endpoint.

![alt text](https://raw.githubusercontent.com/profjordanov/EventSource/master/docs/Capture6.JPG)

Then with the same 'identifier' value execute a POST request to the /api/UpcomingEvents/flag

![alt text](https://raw.githubusercontent.com/profjordanov/EventSource/master/docs/Capture7.JPG)

If we now go to the pgAdmin and check the tables in the 'event-store', they should look like:

![alt text](https://raw.githubusercontent.com/profjordanov/EventSource/master/docs/Capture8.JPG)

In the 'mt_streams' table , there should be only a since record with the provided by us ID and version 2.

In the 'public.mt_events' table, there should be 2 records (for each event that we have registrated).

![alt text](https://raw.githubusercontent.com/profjordanov/EventSource/master/docs/Capture9.JPG)

In the 'mt_doc_upcomingeventview' table, there should be a single record with the current state of our aggragate.

![alt text](https://raw.githubusercontent.com/profjordanov/EventSource/master/docs/Capture10.JPG)

## Strong Benefit: real time reporting as a service
Example : Transactional use cases (saga pattern)

In summary, modern systems have more and more such cases, where they receive a message via HTTP, AMQP, etc and then several components are responsible to process this message.
 
