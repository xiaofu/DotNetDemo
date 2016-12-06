﻿namespace System.Web
{
    using System;

    internal enum AppPerfCounter
    {
        ANONYMOUS_REQUESTS = 0x13,
        API_CACHE_ENTRIES = 0x19,
        API_CACHE_HITS = 0x1b,
        API_CACHE_MISSES = 0x1c,
        API_CACHE_RATIO_BASE = 0x1d,
        API_CACHE_TURNOVER_RATE = 0x1a,
        APP_REQUEST_DISCONNECTED = 0x4d,
        APP_REQUEST_EXEC_TIME = 0x4c,
        APP_REQUEST_WAIT_TIME = 0x4f,
        APP_REQUESTS_REJECTED = 0x4e,
        AUDIT_FAIL = 70,
        AUDIT_SUCCESS = 0x45,
        CACHE_API_TRIMS = 0x55,
        CACHE_OUTPUT_TRIMS = 0x56,
        CACHE_PERCENT_MACH_MEM_LIMIT_USED = 80,
        CACHE_PERCENT_MACH_MEM_LIMIT_USED_BASE = 0x51,
        CACHE_PERCENT_PROC_MEM_LIMIT_USED = 0x52,
        CACHE_PERCENT_PROC_MEM_LIMIT_USED_BASE = 0x53,
        CACHE_TOTAL_TRIMS = 0x54,
        COMPILATIONS = 0x23,
        DEBUGGING_REQUESTS = 0x24,
        ERRORS_COMPILING = 0x26,
        ERRORS_DURING_REQUEST = 0x27,
        ERRORS_PRE_PROCESSING = 0x25,
        ERRORS_TOTAL = 0x29,
        ERRORS_UNHANDLED = 40,
        EVENTS_APP = 0x40,
        EVENTS_ERROR = 0x41,
        EVENTS_HTTP_INFRA_ERROR = 0x43,
        EVENTS_HTTP_REQ_ERROR = 0x42,
        EVENTS_TOTAL = 0x3f,
        EVENTS_WEB_REQ = 0x44,
        FORMS_AUTH_FAIL = 0x4a,
        FORMS_AUTH_SUCCESS = 0x49,
        MEMBER_FAIL = 0x48,
        MEMBER_SUCCESS = 0x47,
        OUTPUT_CACHE_ENTRIES = 30,
        OUTPUT_CACHE_HITS = 0x20,
        OUTPUT_CACHE_MISSES = 0x21,
        OUTPUT_CACHE_RATIO_BASE = 0x22,
        OUTPUT_CACHE_TURNOVER_RATE = 0x1f,
        PIPELINES = 0x2a,
        REQUEST_BYTES_IN = 0x2b,
        REQUEST_BYTES_OUT = 0x2c,
        REQUESTS_EXECUTING = 0x2d,
        REQUESTS_FAILED = 0x2e,
        REQUESTS_IN_APPLICATION_QUEUE = 0x31,
        REQUESTS_NOT_AUTHORIZED = 0x30,
        REQUESTS_NOT_FOUND = 0x2f,
        REQUESTS_SUCCEDED = 0x33,
        REQUESTS_TIMED_OUT = 50,
        REQUESTS_TOTAL = 0x34,
        SESSION_SQL_SERVER_CONNECTIONS = 0x3e,
        SESSION_STATE_SERVER_CONNECTIONS = 0x3d,
        SESSIONS_ABANDONED = 0x36,
        SESSIONS_ACTIVE = 0x35,
        SESSIONS_TIMED_OUT = 0x37,
        SESSIONS_TOTAL = 0x38,
        TOTAL_CACHE_ENTRIES = 20,
        TOTAL_CACHE_HITS = 0x16,
        TOTAL_CACHE_MISSES = 0x17,
        TOTAL_CACHE_RATIO_BASE = 0x18,
        TOTAL_CACHE_TURNOVER_RATE = 0x15,
        TRANSACTIONS_ABORTED = 0x39,
        TRANSACTIONS_COMMITTED = 0x3a,
        TRANSACTIONS_PENDING = 0x3b,
        TRANSACTIONS_TOTAL = 60,
        VIEWSTATE_MAC_FAIL = 0x4b
    }
}
